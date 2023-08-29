using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public int IdGenre { get; set; }
        public string NameGenre { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
