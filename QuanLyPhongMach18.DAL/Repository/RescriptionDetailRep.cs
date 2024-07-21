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
    public class PrescriptionDetailRep : GenericRep<ClinicManagement18Context, PrescriptionDetail>
    {
        #region --Overrides --
        public override PrescriptionDetail Read(int id)
        {
            var res = All.FirstOrDefault(p => p.PrescriptionDetailId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = All.First(i => i.PrescriptionDetailId == id);
            m = Delete(m);
            return m.PrescriptionDetailId;
        }

        #endregion

        #region -- Method --
        public SingleRsp CreatePrescriptionDetail(PrescriptionDetail prescriptionDetail)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.PrescriptionDetails.Add(prescriptionDetail);
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

        public SingleRsp UpdatePrescriptionDetail(PrescriptionDetail prescriptionDetail)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.PrescriptionDetails.Update(prescriptionDetail);
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

        public SingleRsp DeletePrescriptionDetail(PrescriptionDetail prescriptionDetail)
        {
            var res = new SingleRsp();

            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.PrescriptionDetails.Remove(prescriptionDetail);
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
