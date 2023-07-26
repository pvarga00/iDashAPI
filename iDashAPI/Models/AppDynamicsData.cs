using System;
using System.Collections.Generic;

namespace iDashAPI.Models
{
    public partial class AppDynamicsData
    {
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string MetricName { get; set; }
        public string MetricValue { get; set; }
        public DateTime? DateInserted { get; set; }
        public DateTime? DateLastUpdated { get; set; }
        public int Id { get; set; }
    }
}
