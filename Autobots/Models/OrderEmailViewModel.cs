using Autobots.Entities.Models.DB;
using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Models
{
    public class OrderEmailViewModel : Email
    {
        public string Name { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string carmake { get; set; }
        public string carmodel { get; set; }
        public string timings { get; set; }
        public int year { get; set; }
        public int millege { get; set; }
        public string address { get; set; }
        public List<PriceChart> pricesofsubservices { get; set; }
        public decimal tax { get; set; }
        public decimal totalprice { get; set; }

        public decimal servicechargers { get; set; }


    }
}