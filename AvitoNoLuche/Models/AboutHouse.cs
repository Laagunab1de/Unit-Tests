using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class AboutHouse
    {
        public AboutHouse()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string? YearOfConsruction { get; set; }
        public int? IdTypeHouse { get; set; }
        public int? IdParking { get; set; }
        public int IdStatus { get; set; }

        public virtual Parking? IdParkingNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; } = null!;
        public virtual TypeHouse? IdTypeHouseNavigation { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
