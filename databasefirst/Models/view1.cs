using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class View1
    {
        public string NameBook { get; set; } = null!;
        public string NameAuthor { get; set; } = null!;
        public string SurnameAuthor { get; set; } = null!;
        public string? FathernameAuthor { get; set; }
        public int PriceBook { get; set; }
        public string NameGenre { get; set; } = null!;
    }
}
