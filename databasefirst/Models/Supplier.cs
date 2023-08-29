using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Supplies = new HashSet<Supply>();
        }

        public int IdSupplier { get; set; }
        public string NameSupplier { get; set; } = null!;
        public string PhoneSupplier { get; set; } = null!;
        public string AdressSupplier { get; set; } = null!;

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
