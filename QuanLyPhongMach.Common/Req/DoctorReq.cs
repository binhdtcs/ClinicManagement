using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach18.Common.Req
{
    public class DoctorReq
    {
        public int DoctorId { get; set; }

        public int? UserId { get; set; }

        public string Specialty { get; set; } = null!;

        public int? ExperienceYears { get; set; }

        public string? Phone { get; set; }
    }
}
