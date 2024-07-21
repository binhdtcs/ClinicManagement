using System;
using System.Collections.Generic;

namespace QuanLyPhongMach18.DAL.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public int? UserId { get; set; }

    public string Specialty { get; set; } = null!;

    public int? ExperienceYears { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User? User { get; set; }
}
