using QuanLyPhongMach18.Common.DAL;
using QuanLyPhongMach18.Common.Rsp;
using QuanLyPhongMach18.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.DAL.Repository
{
    public class DoctorRep : GenericRep<ClinicManagement18Context, Doctor>
    {
        #region -- Overrides --
        public override Doctor Read(int id)
        {
            var res = All.FirstOrDefault(d => d.DoctorId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = All.First(i => i.DoctorId == id);
            m = Delete(m);
            return m.DoctorId;
        }
        #endregion

        #region -- Method --
        public SingleRsp CreateDoctor(Doctor doctor)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Doctors.Add(doctor);
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
        public SingleRsp UpdateDoctor(Doctor doctor)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Doctors.Update(doctor);
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
        public SingleRsp DeleteDoctor(Doctor doctor)
        {
            var res = new SingleRsp();

            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Doctors.Remove(doctor);
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
        public List<Doctor> SearchDoctor(string keyWord)
        {
            return All.Where(x => x.Specialty.Contains(keyWord)).ToList();
        }
        #endregion
    }
}
