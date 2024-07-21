using QuanLyPhongMach18.Common.BLL;
using QuanLyPhongMach18.Common.DAL;
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
    public class AppointmentSvc : GenericSvc<AppointmentRep, Appointment>
    {
        private AppointmentRep appointmentRep;
        #region -- Overrides --
        public AppointmentSvc()
        {
            appointmentRep = new AppointmentRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Update(Appointment m)
        {
            var res = new SingleRsp();
            var m1 = m.AppointmentId > 0 ? _rep.Read(m.AppointmentId) : _rep.Read(m.AppointmentId);

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

        public SingleRsp CreateAppointment(AppointmentReq appointmentReq)
        {
            var res = new SingleRsp();
            Appointment appointment = new Appointment();
            appointment.AppointmentId = appointmentReq.AppointmentId;
            appointment.PatientId = appointmentReq.PatientId;
            appointment.DoctorId = appointmentReq.DoctorId;
            appointment.AppointmentDate = appointmentReq.AppointmentDate;
            appointment.Status = appointmentReq.Status;
            res = appointmentRep.CreateAppointment(appointment);
            return res;
        }

        public SingleRsp SearchAppointment(SearchAppointmentReq s)
        {
            var res = new SingleRsp();
            //Lấy danh sách lịch khám theo từ khóa
            var medicines = appointmentRep.SearchAppointment(s.Keyword);
            //xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = medicines.Count;
            totalPages = pCount % s.Size == 0 ? pCount / s.Size : 1 + pCount / s.Size;
            var p = new
            {
                Data = medicines.Skip(offset).Take(s.Size).ToList(),
                s.Page,
                s.Size
            };
            res.Data = p;
            return res;
        }

        public SingleRsp UpdateAppointment(AppointmentReq appointmentReq)
        {
            var res = new SingleRsp();
            Appointment appointment = new Appointment();
            appointment.AppointmentId = appointmentReq.AppointmentId;
            appointment.PatientId = appointmentReq.PatientId;
            appointment.DoctorId = appointmentReq.DoctorId;
            appointment.AppointmentDate = appointmentReq.AppointmentDate;
            appointment.Status = appointmentReq.Status;
            res = appointmentRep.UpdateAppointment(appointment);
            return res;
        }

        public SingleRsp DeleteAppointment(AppointmentReq appointmentReq)
        {
            var res = new SingleRsp();
            Appointment appointment = new Appointment();
            appointment.AppointmentId = appointmentReq.AppointmentId;
            appointment.PatientId = appointmentReq.PatientId;
            appointment.DoctorId = appointmentReq.DoctorId;
            appointment.AppointmentDate = appointmentReq.AppointmentDate;
            appointment.Status = appointmentReq.Status;
            res = appointmentRep.DeleteAppointment(appointment);
            return res;
        }
    }
}
