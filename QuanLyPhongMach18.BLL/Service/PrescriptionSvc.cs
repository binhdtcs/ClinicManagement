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
    public class PrescriptionSvc : GenericSvc<PrescriptionRep, Prescription>
    {
        private PrescriptionRep prescriptionRep;
        #region --Overrides--
        public PrescriptionSvc()
        {
            prescriptionRep = new PrescriptionRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Update(Prescription m)
        {
            var res = new SingleRsp();
            var m1 = m.PrescriptionId > 0 ? _rep.Read(m.PrescriptionId) : _rep.Read(m.PrescriptionId);

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

        public SingleRsp CreatePrescription(PrescriptionReq prescriptionReq)
        {
            var res = new SingleRsp();
            Prescription prescription = new Prescription();
            prescription.PrescriptionId = prescriptionReq.PrescriptionId;
            prescriptionReq.RecordId = prescriptionReq.RecordId;
            prescriptionReq.MedicineId = prescriptionReq.MedicineId;
            prescriptionReq.PrescriptionDate = prescriptionReq.PrescriptionDate;
            res = prescriptionRep.CreatePrescription(prescription);
            return res;
        }

        public SingleRsp UpdatePrescription(PrescriptionReq prescriptionReq)
        {
            var res = new SingleRsp();
            Prescription prescription = new Prescription();
            prescription.PrescriptionId = prescriptionReq.PrescriptionId;
            prescriptionReq.RecordId = prescriptionReq.RecordId;
            prescriptionReq.MedicineId = prescriptionReq.MedicineId;
            prescriptionReq.PrescriptionDate = prescriptionReq.PrescriptionDate;
            res = prescriptionRep.UpdatePrescription(prescription);
            return res;
        }

        public SingleRsp DeletePrescription(PrescriptionReq prescriptionReq)
        {
            var res = new SingleRsp();
            Prescription prescription = new Prescription();
            prescription.PrescriptionId = prescriptionReq.PrescriptionId;
            prescriptionReq.RecordId = prescriptionReq.RecordId;
            prescriptionReq.MedicineId = prescriptionReq.MedicineId;
            prescriptionReq.PrescriptionDate = prescriptionReq.PrescriptionDate;
            res = prescriptionRep.DeletePrescription(prescription);
            return res;
        }



    }
}
