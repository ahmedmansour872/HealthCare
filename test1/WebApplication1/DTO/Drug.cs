using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.DTO
{
    public partial class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime AddDate { get; set; }
        public int PharmacistId { get; set; }
        public string Category { get; set; }
        public virtual Pharmacist Pharmacist { get; set; }
    }
}
