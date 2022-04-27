using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.DTO
{
    public partial class Pharmacist
    {
        public Pharmacist()
        {
            Drugs = new HashSet<Drug>();
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public int MilitaryNumber { get; set; }
        public int NationalId { get; set; }
        public string Rank { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Mname2 { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Drug> Drugs { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
