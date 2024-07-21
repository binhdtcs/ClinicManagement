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
    public class PatientRep : GenericRep<ClinicManagement18Context, Patient>
    {
        #region -- Overrides --
        public override Patient Read(int id)
        {
            var res = All.FirstOrDefault(p => p.PatientId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = All.First(i => i.PatientId == id);
            m = Delete(m);
            return m.PatientId;
        }

        #endregion
        #region -- Method--
        public SingleRsp CreatePatient(Patient patient)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Patients.Add(patient);
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

        public SingleRsp UpdatePatient(Patient patient)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Patients.Update(patient);
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

        public SingleRsp DeletePatient(Patient patient)
        {
            var res = new SingleRsp();

            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Patients.Remove(patient);
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
        #endregion
    }
}
