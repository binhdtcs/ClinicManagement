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
    public class AppointmentRep : GenericRep<ClinicManagement18Context, Appointment>
    {
        #region -- Overrides -- 
        public override Appointment Read(int id)
        {
            var res = All.FirstOrDefault(a => a.AppointmentId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = All.First(i => i.AppointmentId == id);
            m = Delete(m);
            return m.AppointmentId;
        }
        #endregion

        #region --Method --

        public SingleRsp CreateAppointment(Appointment appointment)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Appointments.Add(appointment);
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

        public SingleRsp UpdateAppointment(Appointment appointment)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Appointments.Update(appointment);
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

        public SingleRsp DeleteAppointment(Appointment appointment)
        {
            var res = new SingleRsp();

            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Appointments.Remove(appointment);
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


        public List<Appointment> SearchAppointment(string keyWord)
        {
            return All.Where(x => x.Status.Contains(keyWord)).ToList();
        }
        #endregion
    }
}
