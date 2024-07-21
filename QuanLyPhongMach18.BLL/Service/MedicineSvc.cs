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
    public class MedicineSvc : GenericSvc<MedicineRep, Medicine>
    {
        private MedicineRep medicineRep;
        #region -- Overrides -- 

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        public MedicineSvc()
        {
            medicineRep = new MedicineRep();
        }
        public override SingleRsp Update(Medicine m)
        {
            var res = new SingleRsp();
            var m1 = m.MedicineId > 0 ? _rep.Read(m.MedicineId) : _rep.Read(m.MedicineId);

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

        public SingleRsp CreateMedicine(MedicineReq medicineReq)
        {
            var res = new SingleRsp();
            Medicine medicine = new Medicine();
            medicine.MedicineId = medicineReq.MedicineId;
            medicine.MedicineName = medicineReq.MedicineName;
            medicine.Description = medicineReq.Description;
            medicine.Price = medicineReq.Price;
            medicine.Quantity = medicineReq.Quantity;
            medicine.Unit = medicineReq.Unit;
            res = medicineRep.CreateMedicine(medicine);
            return res;
        }

        public SingleRsp SearchMedicine(SearchMedicineReq s)
        {
            var res = new SingleRsp();
            //Lấy danh sách thuốc theo từ khóa
            var medicines = medicineRep.SearchMedicine(s.Keyword);
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

        public SingleRsp UpdateMedicine(MedicineReq medicineReq)
        {
            var res = new SingleRsp();
            Medicine medicine = new Medicine();
            medicine.MedicineId = medicineReq.MedicineId;
            medicine.MedicineName = medicineReq.MedicineName;
            medicine.Description = medicineReq.Description;
            medicine.Price = medicineReq.Price;
            medicine.Quantity = medicineReq.Quantity;
            medicine.Unit = medicineReq.Unit;
            res = medicineRep.UpdateMedicine(medicine);
            return res;
        }

        public SingleRsp DeleteMedicine(MedicineReq medicineReq)
        {
            var res = new SingleRsp();
            Medicine medicine = new Medicine();
            medicine.MedicineId = medicineReq.MedicineId;
            medicine.MedicineName = medicineReq.MedicineName;
            medicine.Description = medicineReq.Description;
            medicine.Price = medicineReq.Price;
            medicine.Quantity = medicineReq.Quantity;
            medicine.Unit = medicineReq.Unit;
            res = medicineRep.DeleteMedicine(medicine);
            return res;
        }

    }
}
