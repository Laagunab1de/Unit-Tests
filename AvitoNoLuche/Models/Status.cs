using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class Status
    {
        public Status()
        {
            AboutHouses = new HashSet<AboutHouse>();
        }

        public int Id { get; set; }
        public string Status1 { get; set; } = null!;

        public virtual ICollection<AboutHouse> AboutHouses { get; set; }
    }
}
