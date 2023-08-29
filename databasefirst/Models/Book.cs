using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Book
    {
        public Book()
        {
            BookShops = new HashSet<BookShop>();
            Ordelists = new HashSet<Ordelist>();
        }

        public int IdBook { get; set; }
        public int IdGenre { get; set; }
        public int IdEditorialOffice { get; set; }
        public int IdAuthor { get; set; }
        public string NameBook { get; set; } = null!;
        public int PriceBook { get; set; }

        public virtual Author IdAuthorNavigation { get; set; } = null!;
        public virtual EditorialOffice IdEditorialOfficeNavigation { get; set; } = null!;
        public virtual Genre IdGenreNavigation { get; set; } = null!;
        public virtual ICollection<BookShop> BookShops { get; set; }
        public virtual ICollection<Ordelist> Ordelists { get; set; }
    }
}
