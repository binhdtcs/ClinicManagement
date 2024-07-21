using QuanLyPhongMach18.Common.DAL;
using QuanLyPhongMach18.Common.Rsp;
using QuanLyPhongMach18.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.DAL.Repository
{
    public class UserRep : GenericRep<ClinicManagement18Context, User>
    {
        #region -- Overrides --
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(u => u.UserId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = All.First(i => i.UserId == id);
            m = Delete(m);
            return m.UserId;
        }

        #endregion

        #region -- Method -- 
        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Add(user);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Update(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }

                }
            }
            return res;
        }

        public SingleRsp DeleteUser(User user)
        {
            var res = new SingleRsp();

            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Remove(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }


        public List<User> SearchUser(string keyWord)
        {
            return All.Where(x => x.FullName.Contains(keyWord)).ToList();
        }
        #endregion
    }
}
