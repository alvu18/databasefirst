using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? IdWorker { get; set; }

        public virtual Worker? IdWorkerNavigation { get; set; }
    }
}
