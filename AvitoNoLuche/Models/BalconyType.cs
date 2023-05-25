using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class BalconyType
    {
        public BalconyType()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
