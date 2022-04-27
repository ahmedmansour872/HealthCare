using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.DTO
{
    public partial class BedsNumber
    {
        public BedsNumber()
        {
            ReservedPatients = new HashSet<ReservedPatient>();
        }

        public int BedId { get; set; }
        public int? NumberBed { get; set; }
        public bool? Busy { get; set; }

        public virtual ICollection<ReservedPatient> ReservedPatients { get; set; }
    }
}
