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
    public class PrescriptionDetailSvc : GenericSvc<PrescriptionDetailRep, PrescriptionDetail>
    {
        private PrescriptionDetailRep prescriptionDetailRep;
        #region -- Overrides --
        public PrescriptionDetailSvc()
        {
            prescriptionDetailRep = new PrescriptionDetailRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Update(PrescriptionDetail m)
        {
            var res = new SingleRsp();
            var m1 = m.PrescriptionDetailId > 0 ? _rep.Read(m.PrescriptionDetailId) : _rep.Read(m.PrescriptionDetailId);

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

        public SingleRsp CreatePrescriptionDetail(PrescriptionDetailReq prescriptionDetailReq)
        {
            var res = new SingleRsp();
            PrescriptionDetail prescriptionDetail = new PrescriptionDetail();
            prescriptionDetail.PrescriptionDetailId = prescriptionDetailReq.PrescriptionDetailId;
            prescriptionDetail.PrescriptionId = prescriptionDetailReq.PrescriptionId;
            prescriptionDetail.MedicineId = prescriptionDetailReq.MedicineId;
            prescriptionDetail.Dosage = prescriptionDetailReq.Dosage;
            prescriptionDetail.Duration = prescriptionDetailReq.Duration;
            prescriptionDetail.Quantity = prescriptionDetailReq.Quantity;
            res = prescriptionDetailRep.CreatePrescriptionDetail(prescriptionDetail);
            return res;
        }

        public SingleRsp UpdatePrescriptionDetail(PrescriptionDetailReq prescriptionDetailReq)
        {
            var res = new SingleRsp();
            PrescriptionDetail prescriptionDetail = new PrescriptionDetail();
            prescriptionDetail.PrescriptionDetailId = prescriptionDetailReq.PrescriptionDetailId;
            prescriptionDetail.PrescriptionId = prescriptionDetailReq.PrescriptionId;
            prescriptionDetail.MedicineId = prescriptionDetailReq.MedicineId;
            prescriptionDetail.Dosage = prescriptionDetailReq.Dosage;
            prescriptionDetail.Duration = prescriptionDetailReq.Duration;
            prescriptionDetail.Quantity = prescriptionDetailReq.Quantity;
            res = prescriptionDetailRep.UpdatePrescriptionDetail(prescriptionDetail);
            return res;
        }

        public SingleRsp DeletePrescriptionDetail(PrescriptionDetailReq prescriptionDetailReq)
        {
            var res = new SingleRsp();
            PrescriptionDetail prescriptionDetail = new PrescriptionDetail();
            prescriptionDetail.PrescriptionDetailId = prescriptionDetailReq.PrescriptionDetailId;
            prescriptionDetail.PrescriptionId = prescriptionDetailReq.PrescriptionId;
            prescriptionDetail.MedicineId = prescriptionDetailReq.MedicineId;
            prescriptionDetail.Dosage = prescriptionDetailReq.Dosage;
            prescriptionDetail.Duration = prescriptionDetailReq.Duration;
            prescriptionDetail.Quantity = prescriptionDetailReq.Quantity;
            res = prescriptionDetailRep.DeletePrescriptionDetail(prescriptionDetail);
            return res;
        }

    }
}
