using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class BookShop
    {
        public int IdBookShop { get; set; }
        public int IdBook { get; set; }
        public int IdShop { get; set; }

        public virtual Book IdBookNavigation { get; set; } = null!;
        public virtual Shop IdShopNavigation { get; set; } = null!;
    }
}
