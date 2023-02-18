using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autobots.Entities.DataAccess;
using Autobots.Entities.Models.DB;
using Autobots.Entities.Models.ViewModels;
using Newtonsoft.Json.Linq;
using Autobots.Entities.Models.Defaults;
using Autobots.Entities.DataAccess.Repositories;
//using Microsoft.AspNet.Identity;

namespace Autobots.BLL.Manager
{
    public class OrderManager
    {
        private DbService _db;
        private UserRepository _user;

        public OrderManager()
        {
            _db = new DbService();
            _user = new UserRepository();
        }

        public List<CarMake> get_all_makes()
        {

            return _db.CarMakes.GetAll().Where(m => m.IsActive.Equals(true)).ToList();

        }

        public List<CarModel> get_all_models()
        {

            return _db.CarModels.GetAll().Where(m => m.IsActive.Equals(true)).ToList();

        }
        public List<TimingSlot> get_all_timeslots()
        {

            return _db.TimingSlots.GetAll().Where(m => m.IsActive.Equals(true)).ToList();

        }
        public List<CarModel> get_model_by_makeId(int id)
        {

            return _db.CarModels.Get().Where(x => x.MakeId == id && x.IsActive.Equals(true)).ToList();
        }

        public List<PriceChart> get_price_by_subserviceId(List<int> id)
        {

            return _db.PriceCharts.Get(id).Where(m => m.IsActive.Equals(true)).ToList();

        }


        public Booking add_booking(Booking book)
        {

            return _db.Booking.Insert(book);
        }
        public OrderResponseModel CreateOrder(AppointmentViewModel model, List<int> pricesid, string userid)
        {
            var user = new UserVm();
            var fname = "Please Enter Your Name";
            var Contact = "Enter Number";
            var Email = "Enter Valid Email";
            if (userid != null)
            {
                user = _user.GetUserById(userid);
            }
            else
            {
                user = null;
            }

            // var prices = _db.PriceCharts.Get(JArray.Parse(model.selectedsubservices).ToObject<List<int>>());
            var prices = _db.PriceCharts.Get(pricesid).ToList();

            var selectedServices = prices.Select(x => x.SubService.Service).Where(x => x.IsActive.Equals(true) && x.IsAddOn.Equals(false)).Distinct().ToList();


            decimal totalprice = prices.Sum(x => x.Price);
            totalprice += selectedServices.Sum(x => x.Price);


            Order order = _db.Orders.Insert(new Order
            {
                UserId = userid,
                Address = model.address,
                Millage = model.millage,
                TimeSlotId = model.timings,
                Year = model.year,
                CreatedAt = DateTime.Now,
                Price = totalprice,
                ModelId = model.model_id,
                status = (int)BookingType.Pending,
               
            });
            order.TimingSlot = _db.TimingSlots.Get(order.TimeSlotId);

            List<OrderDetail> orderlist = prices.Select(x => new OrderDetail()
            {
                OrderId = order.Id,
                Price = x.Price,
                SubServiceId = x.SubServiceId,
                CreatedAt = DateTime.Now,
            }).ToList();

            List<OrderServiceCharge> orederServiceCharges = selectedServices.Select(
            x => new OrderServiceCharge()
            {
                OrderId = order.Id,
                Price = x.Price,
                ServiceId = x.Id,
                CreatedAt = DateTime.Now,
            }).ToList();

            _db.OrderDetails.InsertRange(orderlist);
            _db.OrderServiceCharge.InsertRange(orederServiceCharges);

            if (user == null)
            {
                OrderResponseModel orderresponse = new OrderResponseModel()
                {
                    orderid = order.Id,
                    address = order.Address,
                    millege = order.Millage,

                    Name = fname,
                    email = Email,
                    contact = Contact,
                    year = order.Year,
                    timings = order.TimingSlot.StartingTime.ToShortTimeString() + order.TimingSlot.EndingTime.ToShortTimeString(),
                    carmake = order.CarModel.Make.Name,
                    carmodel = order.CarModel.Name,
                    totalprice = order.Price,
                    pricesofsubservices = prices,
                    servicechargers = orederServiceCharges

                };
                return orderresponse;


            }
            else
            {
                OrderResponseModel orderresponse = new OrderResponseModel()
                {
                    orderid = order.Id,
                    address = order.Address,
                    millege = order.Millage,

                    Name = (user.FirstName != null) ? user.FirstName : "Enter Name",
                    email = (user.EmailAddress != null) ? user.EmailAddress : "Email",
                    contact = (user.PhoneNo != null) ? user.PhoneNo : "Phone Number",
                    year = order.Year,
                    timings = order.TimingSlot.StartingTime.ToShortTimeString() + order.TimingSlot.EndingTime.ToShortTimeString(),
                    carmake = order.CarModel.Make.Name,
                    carmodel = order.CarModel.Name,
                    totalprice = order.Price,
                    pricesofsubservices = prices,
                    servicechargers = orederServiceCharges

                };


                return orderresponse;

            }

          

        }



        public bool UpdateOrderbyOrderID(OrderResponseModel model)
        {
            var order = _db.Orders.Get(model.orderid);
            order.Name = model.Name;
            order.Email = model.email;
            order.PhoneNo = model.contact;
            try
            {
                _db.Orders.Update(order);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}