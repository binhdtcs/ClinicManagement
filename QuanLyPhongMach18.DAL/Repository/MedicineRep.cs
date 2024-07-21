using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using QuanLyPhongMach18.Common.DAL;
using QuanLyPhongMach18.Common.Rsp;
using QuanLyPhongMach18.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.DAL.Repository
{
    public class MedicineRep : GenericRep<ClinicManagement18Context, Medicine>
    {
        #region -- Overrides --

        public override Medicine Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MedicineId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = All.First(i => i.MedicineId == id);
            m = Delete(m);
            return m.MedicineId;
        }

        #endregion

        #region -- Method --

        public SingleRsp CreateMedicine(Medicine medicine)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Medicines.Add(medicine);
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

        public SingleRsp UpdateMedicine(Medicine medicine)
        {
            var res = new SingleRsp();
            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Medicines.Update(medicine);
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

        public SingleRsp DeleteMedicine(Medicine medicine)
        {
            var res = new SingleRsp();

            using (var context = new ClinicManagement18Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Medicines.Remove(medicine);
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


        public List<Medicine> SearchMedicine(string keyWord)
        {
            return All.Where(x => x.MedicineName.Contains(keyWord)).ToList();
        }
        #endregion
    }


}
