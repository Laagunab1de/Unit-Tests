using System;
using System.Collections.Generic;

namespace AvitoNoLuche.Models
{
    public partial class User
    {
        public User()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
