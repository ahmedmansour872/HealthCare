using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.models4
{
    public partial class Doctor
    {
        public Doctor()
        {
            PatientDoctors = new HashSet<PatientDoctor>();
            Prescriptions = new HashSet<Prescription>();
            //ReservedPatients = new HashSet<ReservedPatient>();
        }

        public int Id { get; set; }
        public long MilitaryNumber { get; set; }
        public long NationalId { get; set; }
        public string Rank { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Mname2 { get; set; }
        public string Lname { get; set; }
        public string Specialization { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<PatientDoctor> PatientDoctors { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<ReservedPatient> ReservedPatients { get; set; }
    }
}
