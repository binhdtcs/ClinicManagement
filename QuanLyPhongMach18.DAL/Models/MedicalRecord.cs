﻿using System;
using System.Collections.Generic;

namespace QuanLyPhongMach18.DAL.Models;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? AppointmentId { get; set; }

    public string? Symptoms { get; set; }

    public string? Diagnosis { get; set; }

    public string? Treatment { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
