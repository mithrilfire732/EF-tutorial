using System;
using System.Collections.Generic;

#nullable disable

namespace EF_tutorial.Models
{
    public partial class CatalogFull
    {
        public string MajorCode { get; set; }
        public string Description { get; set; }
        public string ClassCode { get; set; }
        public string Subject { get; set; }
        public string Lastname { get; set; }
        public bool IsTenured { get; set; }
    }
}
