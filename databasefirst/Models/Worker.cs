using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public int IdWorker { get; set; }
        public string NameWorker { get; set; } = null!;
        public string SurnameWorker { get; set; } = null!;
        public string? FathernameWorker { get; set; }
        public string NumberWorker { get; set; } = null!;
        public string AdressWorker { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
