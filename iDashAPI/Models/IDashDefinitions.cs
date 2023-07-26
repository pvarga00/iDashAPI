using System;
using System.Collections.Generic;

namespace iDashAPI.Models
{
    public partial class IDashDefinitions
    {
        public string FriendlyMetricName { get; set; }
        public string Definition { get; set; }
        public string Significance { get; set; }
        public DateTime InsertedDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
