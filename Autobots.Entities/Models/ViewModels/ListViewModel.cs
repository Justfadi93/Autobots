using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public bool Selected { get; set; }

    }
}