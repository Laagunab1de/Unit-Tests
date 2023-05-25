using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class Repair
    {
        public Repair()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string Repair1 { get; set; } = null!;

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
