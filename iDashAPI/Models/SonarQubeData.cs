using System;
using System.Collections.Generic;

namespace iDashAPI.Models
{
    public partial class SonarQubeData
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string MetricName { get; set; }
        public string MetricValue { get; set; }
        public DateTime? DateInserted { get; set; }
        public DateTime? DateLastUpdated { get; set; }
    }
}
