using Autobots.Entities.DataAccess;
using Autobots.Entities.Models.DB;
using System.Collections.Generic;
using System.Linq;
using Autobots.Entities.Models.ViewModels;

namespace Autobots.BLL.Manager
{
    public class PriceManager
    {
        private readonly DbService _db;
        public PriceManager()
        {
            _db = new DbService();
        }

        public List<UpdatePriceChart> get_full_price_chart()
        {
            var subServices = _db.SubServices.Get().Where(x=>x.IsActive.Equals(true)).ToList();
            var cars = _db.CarModels.Get().Where(x => x.IsActive.Equals(true)).ToList();
            var oldPriceChart = _db.PriceCharts.GetAll().ToList();

            var priceChart = new List<UpdatePriceChart>();

            foreach (var car in cars)
            {
                foreach (var subService in subServices)
                {
                    var oldPrice = oldPriceChart.FirstOrDefault(x => x.ModelId == car.Id && x.SubServiceId == subService.Id);
                    priceChart.Add(new UpdatePriceChart()
                    {
                        ModelId = car.Id,
                        CarModelName = car.Name,
                        CarMakeName = car.Make.Name,
                        SubServiceId = subService.Id,
                        SubServiceName = subService.Name,
                        ServiceName = subService.Service.Name,
                        IsAdon = subService.Service.IsAddOn,
                        Price = oldPrice?.Price ?? 0
                    });
                }
            }

            return priceChart.OrderBy(x => x.CarModelName).ToList();
        }

        public void UpdatePriceChart(int carId, int serviceId, decimal price)
        {
            var oldPrice = _db.PriceCharts.Get().Where(x => x.IsActive.Equals(true)).FirstOrDefault(x => x.ModelId == carId && x.SubServiceId == serviceId);
            if (oldPrice == null)
            {
                _db.PriceCharts.Insert(new PriceChart()
                {
                    SubServiceId = serviceId,
                    ModelId = carId,
                    Price = price
                });
            }
            else
            {
                oldPrice.Price = price;
                _db.PriceCharts.Update(oldPrice);
            }
        }


        public PriceChart add_Price(PriceChart price)
        {
            return _db.PriceCharts.Insert(price);
        }



        //public List<PriceChart> get_full_price_chart()
        //{
        //    return _db.PriceCharts.GetAll().ToList();
        //}

    }
}