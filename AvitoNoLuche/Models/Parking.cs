using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class Parking
    {
        public Parking()
        {
            AboutHouses = new HashSet<AboutHouse>();
        }

        public int Id { get; set; }
        public string Parking1 { get; set; } = null!;

        public virtual ICollection<AboutHouse> AboutHouses { get; set; }
    }
}
