using Autobots.Entities.Context;
using Autobots.Entities.DataAccess;
using Autobots.Entities.DataAccess.Repositories;
using Autobots.Entities.Models.DB;
using Autobots.Entities.Models.Defaults;
using Autobots.Entities.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Autobots.BLL.Manager
{
    public class AdminDashboardManager
    {
        private readonly DbService _db;
        private readonly UserRepository _user;
        public AdminDashboardManager()
        {
            _db = new DbService();
            _user = new UserRepository();
        }
        public List<ApplicationUser> GetAllCustomUser()
        {
            return _user.GetAllCustomuser();
        }
        public UserVm Getuserbyuserid(string id)
        {
            return _user.GetUserById(id);
        }



        public List<Complaint> GetAllComplains()
        {
            var list = _db.Complaint.Get().ToList();
            return list;
        }

        public Complaint GetComplainById(int id)
        {
            return _db.Complaint.Get(id);
        }


        public List<Service> GetAllSerivces()
        {
            return _db.Services.Get().Where(m => m.IsActive.Equals(true)).ToList();
        }

        public List<SubService> GetAllSubSerivces()
        {
            return _db.SubServices.Get().Where(m => m.IsActive.Equals(true)).ToList();
        }



        public bool AddService(Service model)
        {
            try
            {

                _db.Services.Insert(model);
                return true;

            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool AddSubService(SubService model)
        {
            try
            {

                _db.SubServices.Insert(model);
                return true;

            }
            catch (Exception)
            {

                return false;
            }


        }


        public bool AddTimeSlot(TimingSlot slot)
        {
            try
            {

                _db.TimingSlots.Insert(slot);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TimingSlot> GetAllTimingSlot()
        {

            return _db.TimingSlots.GetAll().Where(m => m.IsActive.Equals(true)).ToList();
        }

        public bool DeleteTimeslot(int id)
        {

            var timeslot = _db.TimingSlots.Get(id);
            try
            {
                _db.TimingSlots.Delete(timeslot);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteService(int id)
        {

            var service = _db.Services.Get(id);
            try
            {
                _db.Services.Delete(service);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteSubService(int id)
        {

            var service = _db.SubServices.Get(id);
            try
            {
                _db.SubServices.Delete(service);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Order> GetAllBookings()
        {
            var list = _db.Orders.GetAll().Where(x => x.IsActive.Equals(true)).ToList();

            return list;

        }


        public List<Order> GetTodayAllBookings()
        {
            var list = _db.Orders.GetAll().Where(x => x.IsActive.Equals(true) && x.CreatedAt == DateTime.Today).ToList();

            return list;

        }

        public decimal GetRevenue()
        {
            var list = _db.Orders.Get().ToList();

            decimal revenue = list.Sum(x => x.Price);
            return revenue;

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
            catch (Exception)
            {
                return false;
            }

        }


        public List<ApplicationUser> GetAllCustomers()
        {

            return _user.GetallCustomuser();

        }

        public List<DbOrdersChart> OrdersChart()
        {
            var startDate = DateTime.Now.AddMonths(-12).Date;
            var endDate = DateTime.Now.Date;

            var orderList = _db.Orders.Get()
                .Select(ord => new { ord, dateOfOrder = DbFunctions.TruncateTime(ord.CreatedAt) })
                .Where(t => t.dateOfOrder >= startDate && t.dateOfOrder <= endDate)
                .GroupBy(t => t.dateOfOrder.Value.Month)
                .Select(ordGrp => new DbOrdersChart1
                {
                    Month = ordGrp.Key,
                    CompletedPrice = ordGrp.Where(x => x.ord.status == (int)BookingType.Complete).Sum(x => x.ord.Price),
                    CompletedCount = ordGrp.Where(x => x.ord.status == (int)BookingType.Complete).Count(),
                    PendingPrice = ordGrp.Where(x => x.ord.status == (int)BookingType.Pending).Sum(x => x.ord.Price),
                    PendingCount = ordGrp.Where(x => x.ord.status == (int)BookingType.Pending).Count(),
                    InProgressPrice = ordGrp.Where(x => x.ord.status == (int)BookingType.InProcessing).Sum(x => x.ord.Price),
                    InProgressCount = ordGrp.Where(x => x.ord.status == (int)BookingType.InProcessing).Count()
                }).ToList();
            foreach (var item in orderList)
            {
                item.Date = new DateTime(startDate.Year, item.Month, 1);

            }

            var last12Months = Enumerable.Range(0, 12)
                .Select(i => DateTime.Now.Date.AddMonths(-i))
                .OrderBy(x => x.Date).ToList();
            var result = new List<DbOrdersChart>();

            foreach (var date in last12Months)
            {
                var temp = orderList.FirstOrDefault(x => x.Date.Date.Month == date.Date.Month);
                if (temp == null)
                {
                    result.Add(new DbOrdersChart
                    {
                        Date = date.ToString("MMMM dd, yyyy"),
                        CompletedPrice = 0,
                        CompletedCount = 0,
                        PendingPrice = 0,
                        PendingCount = 0,
                        InProgressPrice = 0,
                        InProgressCount = 0
                    });
                }
                else
                {
                    result.Add(new DbOrdersChart
                    {
                        Date = date.ToString("MMMM dd, yyyy"),
                        CompletedPrice = temp.CompletedPrice,
                        CompletedCount = temp.CompletedCount,
                        PendingPrice = temp.PendingPrice,
                        PendingCount = temp.PendingCount,
                        InProgressPrice = temp.InProgressPrice,
                        InProgressCount = temp.InProgressCount
                    });
                }
            }
            return result;
        }
        public Order GetBookingById(int id)
        {
            return _db.Orders.Get(id);
        }
        public bool getdiscount(decimal price, int orderid)
        {
            var order = GetBookingById(orderid);
            order.Price = order.Price - price;
            try
            {
                _db.Orders.Update(order);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }
    }
}