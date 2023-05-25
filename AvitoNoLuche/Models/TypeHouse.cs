using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class TypeHouse
    {
        public TypeHouse()
        {
            AboutHouses = new HashSet<AboutHouse>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<AboutHouse> AboutHouses { get; set; }
    }
}
