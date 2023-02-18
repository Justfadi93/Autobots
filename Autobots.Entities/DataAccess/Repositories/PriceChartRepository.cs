using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autobots.Entities.Context;
using Autobots.Entities.Models.DB;

namespace Autobots.Entities.DataAccess.Repositories
{
    public class PriceChartRepository : Repository<PriceChart>
    {
        public PriceChartRepository(ApplicationDbContext contect) : base(contect)
        {
        }
    }
}