using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Shop
    {
        public Shop()
        {
            BookShops = new HashSet<BookShop>();
        }

        public int IdShop { get; set; }
        public int? IdSupply { get; set; }
        public int? CountBook { get; set; }

        public virtual Supply? IdSupplyNavigation { get; set; }
        public virtual ICollection<BookShop> BookShops { get; set; }
    }
}
