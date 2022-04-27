using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.models4
{
    public partial class PatientDoctor
    {
        public int Id { get; set; }
        public int Idpatient { get; set; }
        public int Iddoctor { get; set; }
        public DateTime? Date { get; set; }

        public virtual Doctor IddoctorNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
