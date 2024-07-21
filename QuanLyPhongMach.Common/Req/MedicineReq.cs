using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.Common.Req
{
    public class MedicineReq
    {
        public int MedicineId { get; set; }

        public string MedicineName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public string? Unit { get; set; }
    }
}
