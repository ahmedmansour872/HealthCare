﻿using System;
using System.Collections.Generic;
using System.Numerics;

#nullable disable

namespace WebApplication1.DTO
{
    public partial class Patient
    {
        public Patient()
        {
            DiseasHistories = new HashSet<DiseasHistory>();
            PatientDoctors = new HashSet<PatientDoctor>();
            //Inbeds = new HashSet<Inbed>();
        }

        public int Id { get; set; }
        public long MilitaryNumber { get; set; }
        public string Rank { get; set; }
        public long NationalId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Mname2 { get; set; }
        public string Lname { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public bool Reserved { get; set; }
        public int? ReceptionestId { get; set; }
        public int? PharmacistId { get; set; }
        public int age { get; set; }
        public virtual Pharmacist Pharmacist { get; set; }
        public virtual Receptionest Receptionest { get; set; }
        public virtual ICollection<DiseasHistory> DiseasHistories { get; set; }
        public virtual ICollection<PatientDoctor> PatientDoctors { get; set; }
        // public virtual ICollection<Inbed> Inbeds { get; set; }
        public virtual ICollection<ReservedPatient> ReservedPatients { get; set; }
    }
}
