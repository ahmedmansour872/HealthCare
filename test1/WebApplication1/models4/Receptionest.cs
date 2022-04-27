using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.models4
{
    public partial class Receptionest
    {
        public Receptionest()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public long MilitaryNumber { get; set; }
        public long NationalId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Mname2 { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
