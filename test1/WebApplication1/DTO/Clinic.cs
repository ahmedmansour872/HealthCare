using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.DTO
{
    public partial class Clinic
    {
        public Clinic()
        {
            DiseasHistories = new HashSet<DiseasHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DiseasHistory> DiseasHistories { get; set; }

    }
}
