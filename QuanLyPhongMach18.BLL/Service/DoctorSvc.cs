using QuanLyPhongMach18.Common.BLL;
using QuanLyPhongMach18.Common.Req;
using QuanLyPhongMach18.Common.Rsp;
using QuanLyPhongMach18.DAL.Models;
using QuanLyPhongMach18.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.BLL.Service
{
    public class DoctorSvc : GenericSvc<DoctorRep, Doctor>
    {
        private DoctorRep doctorRep;
        #region -- Overrides -- 
        public override SingleRsp Update(Doctor m)
        {
            var res = new SingleRsp();
            var m1 = m.DoctorId > 0 ? _rep.Read(m.DoctorId) : _rep.Read(m.DoctorId);

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
        public DoctorSvc()
        {
            doctorRep = new DoctorRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        #endregion

        public SingleRsp CreateDoctor(DoctorReq doctorReq)
        {
            var res = new SingleRsp();
            Doctor doctor = new Doctor();
            doctor.DoctorId = doctorReq.DoctorId;
            doctor.UserId = doctorReq.UserId;
            doctor.Specialty = doctorReq.Specialty;
            doctor.ExperienceYears = doctorReq.ExperienceYears;
            doctor.Phone = doctorReq.Phone;
            res = doctorRep.CreateDoctor(doctor);
            return res;
        }

        public SingleRsp SearchDoctor(SearchDoctorReq s)
        {
            var res = new SingleRsp();
            //Lấy danh sách bác sĩ theo từ khóa
            var doctors = doctorRep.SearchDoctor(s.Keyword);
            //xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = doctors.Count;
            totalPages = pCount % s.Size == 0 ? pCount / s.Size : 1 + pCount / s.Size;
            var p = new
            {
                Data = doctors.Skip(offset).Take(s.Size).ToList(),
                s.Page,
                s.Size
            };
            res.Data = p;
            return res;
        }

        public SingleRsp UpdateDoctor(DoctorReq doctorReq)
        {
            var res = new SingleRsp();
            Doctor doctor = new Doctor();
            doctor.DoctorId = doctorReq.DoctorId;
            doctor.UserId = doctorReq.UserId;
            doctor.Specialty = doctorReq.Specialty;
            doctor.ExperienceYears = doctorReq.ExperienceYears;
            doctor.Phone = doctorReq.Phone;
            res = doctorRep.UpdateDoctor(doctor);
            return res;
        }

        public SingleRsp DeleteDoctor(DoctorReq doctorReq)
        {
            var res = new SingleRsp();
            Doctor doctor = new Doctor();
            doctor.DoctorId = doctorReq.DoctorId;
            doctor.UserId = doctorReq.UserId;
            doctor.Specialty = doctorReq.Specialty;
            doctor.ExperienceYears = doctorReq.ExperienceYears;
            doctor.Phone = doctorReq.Phone;
            res = doctorRep.DeleteDoctor(doctor);
            return res;
        }
    }
}
