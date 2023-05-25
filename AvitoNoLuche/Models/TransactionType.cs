using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string TypeTransaction { get; set; } = null!;

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
