using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.models4
{
    public partial class BedsNumber
    {
        public BedsNumber()
        {
            ReservedPatients = new HashSet<ReservedPatient>();
        }

        public int BedId { get; set; }
        public int? NumberBed { get; set; }
        public bool? Basy { get; set; }

        public virtual ICollection<ReservedPatient> ReservedPatients { get; set; }
    }
}
