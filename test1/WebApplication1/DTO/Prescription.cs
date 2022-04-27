using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.DTO
{
    public partial class Prescription
    {
        public int Id { get; set; }
        public string DrugName { get; set; }
        public int DrugAmount { get; set; }
        public int DrugAmountPday { get; set; }
        public int Duration { get; set; }
        public int? DoctorId { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public bool Done_Drug { get; set; }
        public int Clin_ID { get; set; }
        public int phar_id { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
