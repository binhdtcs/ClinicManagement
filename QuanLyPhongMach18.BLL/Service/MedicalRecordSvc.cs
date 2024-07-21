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
    public class MedicalRecordSvc : GenericSvc<MedicalRecordRep, MedicalRecord>
    {
        private MedicalRecordRep medicalRecordRep;
        #region -- Overrides --
        public MedicalRecordSvc()
        {
            medicalRecordRep = new MedicalRecordRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Update(MedicalRecord m)
        {
            var res = new SingleRsp();
            var m1 = m.RecordId > 0 ? _rep.Read(m.RecordId) : _rep.Read(m.RecordId);

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

        public SingleRsp CreateMedicalRecord(MedicalRecordReq medicalRecordReq)
        {
            var res = new SingleRsp();
            MedicalRecord medicalRecord = new MedicalRecord();
            medicalRecord.RecordId = medicalRecordReq.RecordId;
            medicalRecord.AppointmentId = medicalRecordReq.AppointmentId;
            medicalRecord.Symptoms = medicalRecordReq.Symptoms;
            medicalRecord.Diagnosis = medicalRecordReq.Diagnosis;
            medicalRecord.Treatment = medicalRecordReq.Treatment;
            res = medicalRecordRep.CreateMedicalRecord(medicalRecord);
            return res;
        }

        public SingleRsp UpdateMedicalRecord(MedicalRecordReq medicalRecordReq)
        {
            var res = new SingleRsp();
            MedicalRecord medicalRecord = new MedicalRecord();
            medicalRecord.RecordId = medicalRecordReq.RecordId;
            medicalRecord.AppointmentId = medicalRecordReq.AppointmentId;
            medicalRecord.Symptoms = medicalRecordReq.Symptoms;
            medicalRecord.Diagnosis = medicalRecordReq.Diagnosis;
            medicalRecord.Treatment = medicalRecordReq.Treatment;
            res = medicalRecordRep.UpdateMedicalRecord(medicalRecord);
            return res;
        }

        public SingleRsp DeleteMedicalRecord(MedicalRecordReq medicalRecordReq)
        {
            var res = new SingleRsp();
            MedicalRecord medicalRecord = new MedicalRecord();
            medicalRecord.RecordId = medicalRecordReq.RecordId;
            medicalRecord.AppointmentId = medicalRecordReq.AppointmentId;
            medicalRecord.Symptoms = medicalRecordReq.Symptoms;
            medicalRecord.Diagnosis = medicalRecordReq.Diagnosis;
            medicalRecord.Treatment = medicalRecordReq.Treatment;
            res = medicalRecordRep.DeleteMedicalRecord(medicalRecord);
            return res;
        }

    }
}
