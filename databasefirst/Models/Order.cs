using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Order
    {
        public Order()
        {
            Ordelists = new HashSet<Ordelist>();
        }

        public int IdOrder { get; set; }
        public int? IdClient { get; set; }
        public int IdWorker { get; set; }
        public DateTime DateOrder { get; set; }

        public virtual Client? IdClientNavigation { get; set; }
        public virtual Worker IdWorkerNavigation { get; set; } = null!;
        public virtual ICollection<Ordelist> Ordelists { get; set; }
    }
}
