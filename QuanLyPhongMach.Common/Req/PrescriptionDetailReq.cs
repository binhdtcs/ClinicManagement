using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.Common.Req
{
    public class PrescriptionDetailReq
    {
        public int PrescriptionDetailId { get; set; }

        public int? PrescriptionId { get; set; }

        public int? MedicineId { get; set; }

        public string? Dosage { get; set; }

        public string? Duration { get; set; }

        public int? Quantity { get; set; }
    }
}
