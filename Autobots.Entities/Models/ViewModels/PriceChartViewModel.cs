using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class PriceChartViewModel
    {
        public List<PriceChart> price_list { get; set; }
        public PriceChartViewModel()
        {
            price_list = new List<PriceChart>();

        }
        public int ModelId { get; set; }
        public int SubServiceId { get; set; }
        public decimal Price { get; set; }
    }


    public class UpdatePriceChart
    {
        public int ModelId { get; set; }
        public string CarModelName { get; set; }
        public string CarMakeName { get; set; }
        public int SubServiceId { get; set; }
        public string SubServiceName { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public bool IsAdon { get; set; }
    }




}