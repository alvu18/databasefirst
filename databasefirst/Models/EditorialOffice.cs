using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class EditorialOffice
    {
        public EditorialOffice()
        {
            Books = new HashSet<Book>();
        }

        public int IdEditorialOffice { get; set; }
        public string? NameEditorialOffice { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
