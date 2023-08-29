using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Ordelist
    {
        public int IdOrderList { get; set; }
        public int IdBook { get; set; }
        public int CountBook { get; set; }
        public int IdOrder { get; set; }
        public int IdShop { get; set; }

        public virtual Book IdBookNavigation { get; set; } = null!;
        public virtual Order IdOrderNavigation { get; set; } = null!;
    }
}
