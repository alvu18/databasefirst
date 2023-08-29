using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int IdAuthor { get; set; }
        public string NameAuthor { get; set; } = null!;
        public string SurnameAuthor { get; set; } = null!;
        public string? FathernameAuthor { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
