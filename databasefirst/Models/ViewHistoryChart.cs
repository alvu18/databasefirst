using System;
using System.Collections.Generic;

namespace databasefirst.Models
{
    public partial class ViewHistoryChart
    {
        public DateTime DateOrder { get; set; }
        public int? TotalPrice { get; set; }
        public string? EmailClient { get; set; }
        public string? NameEditorialOffice { get; set; }
        public string WorkerFullName { get; set; } = null!;
        public string NameBook { get; set; } = null!;
    }
}
