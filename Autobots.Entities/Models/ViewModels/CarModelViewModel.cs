using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class CarModelViewModel
    {
        public List<CarModel> carmodel { get; set; }
        public CarModelViewModel()
        {
            carmodel = new List<CarModel>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MakeId { get; set; }

    }
}