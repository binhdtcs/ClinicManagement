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
    public class MedicalRecordRep : GenericRep<ClinicManagement18Context, MedicalRecord>
    {
        #region --Overrides --
        public override MedicalRecord Read(int id)
        {
            var res = All.FirstOrDefault(r => r.RecordId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = All.First(i => i.RecordId == id);
            m = Delete(m);
            return m.RecordId;
        }

        #endregion

        #region -- Method --
        public SingleRsp CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.MedicalRecords.Add(medicalRecord);
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

        public SingleRsp UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.MedicalRecords.Update(medicalRecord);
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

        public SingleRsp DeleteMedicalRecord(MedicalRecord medicalRecord)
        {
            var res = new SingleRsp();

            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.MedicalRecords.Remove(medicalRecord);
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

