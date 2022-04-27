using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.models4
{
    public partial class Clinic
    {
        public Clinic()
        {
            DiseasHistories = new HashSet<DiseasHistory>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DiseasHistory> DiseasHistories { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
