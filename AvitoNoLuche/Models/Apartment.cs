using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class Apartment
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public decimal Cost { get; set; }
        public string Adress { get; set; } = null!;
        public string? CeilingHeight { get; set; }
        public string Discription { get; set; } = null!;
        public int? Square { get; set; }
        public string? Technique { get; set; }
        public string? Furniture { get; set; }
        public int? IdRepair { get; set; }
        public int? IdTransactionType { get; set; }
        public int? IdBathroomtype { get; set; }
        public int? IdTypeWindows { get; set; }
        public int? Floor { get; set; }
        public int? Rooms { get; set; }
        public int? IdBalconyType { get; set; }
        public int Idhouse { get; set; }
        public int IdUser { get; set; }

        public virtual Bathroom? IdBathroomtype1 { get; set; }
        public virtual BalconyType? IdBathroomtypeNavigation { get; set; }
        public virtual Repair? IdRepairNavigation { get; set; }
        public virtual TransactionType? IdTransactionTypeNavigation { get; set; }
        public virtual TypeWindow? IdTypeWindowsNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual AboutHouse IdhouseNavigation { get; set; } = null!;
    }
}
