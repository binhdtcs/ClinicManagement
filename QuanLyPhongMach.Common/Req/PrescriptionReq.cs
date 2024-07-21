using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.Common.Req
{
    public class PrescriptionReq
    {
        public int PrescriptionId { get; set; }

        public int? RecordId { get; set; }

        public int? MedicineId { get; set; }

        public DateTime? PrescriptionDate { get; set; }

    }
}
