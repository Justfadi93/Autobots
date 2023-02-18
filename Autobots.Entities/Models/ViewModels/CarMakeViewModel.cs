using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class CarMakeViewModel
    {
        public List<CarMake> carmake { get; set; }
        public CarMakeViewModel()
        {
            carmake = new List<CarMake>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}