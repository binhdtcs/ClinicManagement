using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.Common.Req
{
    public class MedicalRecordReq
    {
        public int RecordId { get; set; }

        public int? AppointmentId { get; set; }

        public string? Symptoms { get; set; }

        public string? Diagnosis { get; set; }

        public string? Treatment { get; set; }
    }
}
