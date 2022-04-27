using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.models4
{
    public partial class ReservedPatient
    {
        public int ReservedId { get; set; }
        public int? BedNumber { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Patient BedNumber1 { get; set; }
        public virtual BedsNumber BedNumberNavigation { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
