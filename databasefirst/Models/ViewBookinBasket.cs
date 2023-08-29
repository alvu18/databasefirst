using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class ViewBookinBasket
    {
        public int IdBook { get; set; }
        public int IdGenre { get; set; }
        public int IdEditorialOffice { get; set; }
        public int IdAuthor { get; set; }
        public string NameBook { get; set; } = null!;
        public int PriceBook { get; set; }
        public string FullNameAuthor { get; set; } = null!;
        public int CountBook { get; set; }
    }
}
