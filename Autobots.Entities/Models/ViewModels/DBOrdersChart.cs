using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class DbOrdersChart
    {
        public string Date { get; set; }
        public decimal? CompletedPrice { get; set; }
        public decimal? CompletedCount { get; set; }
        public decimal? PendingPrice { get; set; }
        public decimal? PendingCount { get; set; }
        public decimal? InProgressPrice { get; set; }
        public decimal? InProgressCount { get; set; }
    }

    public class DbOrdersChart1
    {
        public decimal? CompletedPrice { get; set; }
        public decimal? CompletedCount { get; set; }
        public decimal? PendingPrice { get; set; }
        public decimal? PendingCount { get; set; }
        public decimal? InProgressPrice { get; set; }
        public decimal? InProgressCount { get; set; }
        public DateTime Date { get; set; }
        public int Month { get; set; }
    }
}