using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int IdClient { get; set; }
        public string NameClient { get; set; } = null!;
        public string SurnameClient { get; set; } = null!;
        public string? FathernameClient { get; set; }
        public string NumberClient { get; set; } = null!;
        public string? AdressClient { get; set; }
        public string? EmailClient { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
