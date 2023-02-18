using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.Defaults
{
    public abstract class EntityBase : ReportingBase
    {
        public int Id { get; set; }
    }
}