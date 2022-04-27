using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.models4
{
    public partial class Prescription
    {
        public int Id { get; set; }
        public string DrugName { get; set; }
        public int DrugAmount { get; set; }
        public int DrugAmountPday { get; set; }
        public int Duration { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? Date { get; set; }
        public bool? DoneDrug { get; set; }
        public int? ClinId { get; set; }

        public virtual Clinic Clin { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
