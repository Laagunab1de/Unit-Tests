using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class TypeWindow
    {
        public TypeWindow()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string Windows { get; set; } = null!;

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
