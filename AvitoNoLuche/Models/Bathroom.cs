using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class Bathroom
    {
        public Bathroom()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string BathroomType { get; set; } = null!;

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
