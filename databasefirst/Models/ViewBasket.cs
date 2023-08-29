using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class ViewBasket
    {
        public string NameBook { get; set; } = null!;
        public int PriceBook { get; set; }
        public int IdOrderList { get; set; }
        public int IdBook { get; set; }
        public int CountBook { get; set; }
        public int IdOrder { get; set; }
        public int IdShop { get; set; }
        public string FullAuthorName { get; set; } = null!;
    }
}
