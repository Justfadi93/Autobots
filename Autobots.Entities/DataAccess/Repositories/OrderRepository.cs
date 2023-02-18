using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autobots.Entities.Context;
using Autobots.Entities.Models.DB;

namespace Autobots.Entities.DataAccess.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(ApplicationDbContext contect) : base(contect)
        {
        }
    }
}