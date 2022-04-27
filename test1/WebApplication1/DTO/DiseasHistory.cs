using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.DTO
{
    public partial class DiseasHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClinicsId { get; set; }
        public int PatientId { get; set; }
        public bool Waiting { get; set; }
        public string Describe { get; set; }
        public string Mrecommend { get; set; }
        public bool ExtrenalExamination { get; set; }
        public virtual Clinic Clinics { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
