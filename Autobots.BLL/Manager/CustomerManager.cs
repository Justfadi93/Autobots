using Autobots.Entities.DataAccess;
using Autobots.Entities.Models.DB;
using Autobots.Entities.Models.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.BLL.Manager
{
    public class CustomerManager
    {
        private DbService _db;
        public CustomerManager()
        {
            _db = new DbService();
        }
        public List<Order> GetAllPendingBookings()
        {
            var List = _db.Orders.GetAll().Where(x => x.status == (int)BookingType.Pending).ToList();

            return List;

        }
        public List<Order> GetAllProcessingBookings()
        {
            var List = _db.Orders.GetAll().Where(x => x.status == (int)BookingType.InProcessing).ToList();

            return List;

        }


        public List<Order> GetAllPendingBookingsById(string userid)
        {
            var List = _db.Orders.GetAll().Where(x => x.UserId == userid && x.status == (int)BookingType.Pending).ToList();

            return List;

        }

        public List<Order> GetAllBookings()
        {
            var List = _db.Orders.GetAll().ToList();

            return List;

        }
        public List<Order> GetAllCompleteBookings()
        {
            var List = _db.Orders.GetAll().Where(x => x.status == (int)BookingType.Complete).ToList();

            return List;

        }

        public List<Order> GetAllCompleteBookingsById(string userid)
        {
            var List = _db.Orders.GetAll().Where(x => x.UserId == userid && x.status == (int)BookingType.Complete).ToList();

            return List;

        }

        public List<Order> GetAllBookingsById(string userid)
        {
            var List = _db.Orders.GetAll().Where(x => x.UserId == userid).ToList();

            return List;

        }

        public Order GetlastOrder(string userid)
        {

            return _db.Orders.Get().Where(x => x.UserId == userid && x.IsActive.Equals(true)).OrderByDescending(x => x.CreatedAt).Take(1).FirstOrDefault();
        }



        public List<Order> GetrecentBookingsById(string userid)
        {
            var List = _db.Orders.GetAll().Where(x => x.UserId == userid && x.IsActive.Equals(true)).OrderByDescending(x=>x.CreatedAt).Take(5).ToList();
            return List;
        }
        public decimal GetRevenue(string id)
        {
            var list = _db.Orders.Get().Where(x=>x.UserId==id && x.IsActive.Equals(true)).ToList();
            decimal revenue = list.Sum(x => x.Price);
            return revenue;
        }






        public Order GetBookingById(int id)
        {
            return _db.Orders.Get(id);
        }

        public List<OrderDetail> GetBookingDetailByBookingId(int id)
        {
            return _db.OrderDetails.Get().Where(x => x.OrderId == id).ToList();
        }

        public bool UpdateOrderRatingByOrderId(int id,int rate)
        {
            var order = _db.Orders.Get(id);
            order.rating = rate;
            try
            {
                _db.Orders.Update(order);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }



        public bool UpdateStatusByOrderId(int id)
        {
            var order = _db.Orders.Get(id);
            order.status = (int)BookingType.Complete;

            try
            {
                _db.Orders.Update(order);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool UpdateStatustoProcessingByOrderId(int id)
        {
            var order = _db.Orders.Get(id);
            order.status = (int)BookingType.InProcessing;

            try
            {
                _db.Orders.Update(order);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }


        public bool AddComplaint(Complaint com)
        {

            try
            {
                _db.Complaint.Insert(com);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            try
            {
                var order = _db.Orders.Get(id);
                _db.Orders.Remove(order);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Car> getallcarsbyuserid(string userid)
        {
            var List = _db.Car.Get().Where(x => x.CreatedBy == userid).ToList();

            return List;
        }
        public bool AddNewCar(Car model)
        {

            try
            {
                _db.Car.Insert(model);
                
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Car GetCarById(int id)
        {
            return _db.Car.Get(id);
        }
        public List<Order> GetOrderByUserandModel(string userid,int modelid)
        {

            return _db.Orders.Get().Where(x => x.UserId == userid && x.ModelId == modelid).ToList();
        }

        public List<OrderDetail>GetOrderDetailByOrderIds(int id)
        {

            return _db.OrderDetails.Get().Where(x => x.OrderId == id).ToList();
        }
    }
}