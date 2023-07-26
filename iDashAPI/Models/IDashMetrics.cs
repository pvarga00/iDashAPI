using System;
using System.Collections.Generic;

namespace iDashAPI.Models
{
    public partial class IDashMetrics
    {
        public string ApplicationMetricName { get; set; }
        public string FriendlyMetricName { get; set; }
        public string MetricLevel { get; set; }
        public string Bucket { get; set; }
        public DateTime InsertedDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
