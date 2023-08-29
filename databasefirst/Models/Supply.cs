using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Supply
    {
        public Supply()
        {
            Shops = new HashSet<Shop>();
        }

        public int IdSupply { get; set; }
        public int IdSuppler { get; set; }
        public int IdShop { get; set; }
        public DateTime DateSupply { get; set; }

        public virtual Supplier IdSupplerNavigation { get; set; } = null!;
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
