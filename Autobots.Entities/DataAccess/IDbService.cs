using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autobots.Entities.DataAccess.Repositories;
using Autobots.Entities.Models.DB;

namespace Autobots.Entities.DataAccess
{
    public interface IDbService
    {
        Repository<CarMake> CarMakes { get; }
        Repository<CarModel> CarModels { get; }
        Repository<Order> Orders { get; }
        Repository<OrderDetail> OrderDetails { get; }
        Repository<PriceChart> PriceCharts { get; }
        Repository<Service> Services { get; }
        Repository<SubService> SubServices { get; }
        Repository<TimingSlot> TimingSlots { get; }
        Repository<Subscribers> Subscribers { get; }
        Repository<CallNumbers> CallNumbers { get; }
        Repository<Booking> Booking { get; }
        Repository<Complaint> Complaint { get; }
        Repository<Car> Car { get; }
        Repository<OrderServiceCharge> OrderServiceCharge { get; }


    }
}