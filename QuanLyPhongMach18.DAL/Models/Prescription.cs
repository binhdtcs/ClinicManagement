using System;
using System.Collections.Generic;

namespace QuanLyPhongMach18.DAL.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int? RecordId { get; set; }

    public int? MedicineId { get; set; }

    public DateTime? PrescriptionDate { get; set; }

    public virtual Medicine? Medicine { get; set; }

    public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; } = new List<PrescriptionDetail>();

    public virtual MedicalRecord? Record { get; set; }
}
