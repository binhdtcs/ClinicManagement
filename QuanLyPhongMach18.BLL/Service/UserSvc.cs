using QuanLyPhongMach18.Common.BLL;
using QuanLyPhongMach18.Common.Rsp;
using QuanLyPhongMach18.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.DAL.Repository;

namespace QuanLyPhongMach18.BLL.Service
{

    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep userRep;
        #region -- Overrides --
        public UserSvc()
        {
            userRep = new UserRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Update(User m)
        {
            var res = new SingleRsp();
            var m1 = m.UserId > 0 ? _rep.Read(m.UserId) : _rep.Read(m.UserId);

            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }
            return res;
        }
        #endregion

        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.Username = userReq.Username;
            user.Password = userReq.Password;
            user.FullName = userReq.FullName;
            user.Email = userReq.Email;
            user.PhoneNumber = userReq.PhoneNumber;
            user.RoleId = userReq.RoleId;
            res = userRep.CreateUser(user);
            return res;

        }

        public SingleRsp SearchUser(SearchUserReq s)
        {
            var res = new SingleRsp();
            //Lấy danh sách user theo từ khóa
            var users = userRep.SearchUser(s.Keyword);
            //xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = users.Count;
            totalPages = pCount % s.Size == 0 ? pCount / s.Size : 1 + pCount / s.Size;
            var p = new
            {
                Data = users.Skip(offset).Take(s.Size).ToList(),
                s.Page,
                s.Size
            };
            res.Data = p;
            return res;
        }

        public SingleRsp UpdateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.Username = userReq.Username;
            user.Password = userReq.Password;
            user.FullName = userReq.FullName;
            user.Email = userReq.Email;
            user.PhoneNumber = userReq.PhoneNumber;
            user.RoleId = userReq.RoleId;
            res = userRep.UpdateUser(user);
            return res;

        }

        public SingleRsp DeleteUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.Username = userReq.Username;
            user.Password = userReq.Password;
            user.FullName = userReq.FullName;
            user.Email = userReq.Email;
            user.PhoneNumber = userReq.PhoneNumber;
            user.RoleId = userReq.RoleId;
            res = userRep.DeleteUser(user);
            return res;

        }


    }
}
