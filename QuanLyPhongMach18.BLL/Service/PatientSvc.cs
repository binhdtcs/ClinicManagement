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
    public class PatientSvc : GenericSvc<PatientRep, Patient>
    {
        private PatientRep patientRep;
        #region -- Overrides--
        public PatientSvc()
        {
            patientRep = new PatientRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        public override SingleRsp Update(Patient m)
        {
            var res = new SingleRsp();
            var m1 = m.PatientId > 0 ? _rep.Read(m.PatientId) : _rep.Read(m.PatientId);

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

        public SingleRsp CreatePatient(PatientReq patientReq)
        {
            var res = new SingleRsp();
            Patient patient = new Patient();
            patient.PatientId = patientReq.PatientId;
            patient.UserId = patientReq.UserId;
            patient.DateOfBirth = patientReq.DateOfBirth;
            patient.Gender = patientReq.Gender;
            patientReq.Address = patientReq.Address;
            patient.Phone = patientReq.Phone;
            res = patientRep.CreatePatient(patient);
            return res;
        }

        public SingleRsp UpdatePatient(PatientReq patientReq)
        {
            var res = new SingleRsp();
            Patient patient = new Patient();
            patient.PatientId = patientReq.PatientId;
            patient.UserId = patientReq.UserId;
            patient.DateOfBirth = patientReq.DateOfBirth;
            patient.Gender = patientReq.Gender;
            patientReq.Address = patientReq.Address;
            patient.Phone = patientReq.Phone;
            res = patientRep.UpdatePatient(patient);
            return res;
        }

        public SingleRsp DeletePatient(PatientReq patientReq)
        {
            var res = new SingleRsp();
            Patient patient = new Patient();
            patient.PatientId = patientReq.PatientId;
            patient.UserId = patientReq.UserId;
            patient.DateOfBirth = patientReq.DateOfBirth;
            patient.Gender = patientReq.Gender;
            patientReq.Address = patientReq.Address;
            patient.Phone = patientReq.Phone;
            res = patientRep.DeletePatient(patient);
            return res;
        }

    }
}
