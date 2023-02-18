using Autobots.BLL.Manager;
using Autobots.Entities.Models.DB;
using Autobots.Entities.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autobots.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private CustomerManager _customermanager;
        private CarManager _carmanager;
        private OrderManager _ordermanager;


        public CustomerController()
        {
            _customermanager = new CustomerManager();
            _carmanager = new CarManager();
            _ordermanager = new OrderManager();
        }


        // GET: Customer
        public ActionResult Index()
        {
            var user_id = User.Identity.GetUserId();
           // var result = _customermanager.GetrecentBookingsById(user_id);

            DashboardViewModel model = new DashboardViewModel
            {
                listofbookings = _customermanager.GetrecentBookingsById(user_id)
            };

            return View(model);
        }



        public ActionResult Bookings()
        {
            var user_id = User.Identity.GetUserId();
            var listofbookings = _customermanager.GetAllBookingsById(user_id);
            return View(listofbookings);
        }
        public ActionResult Cars()
        {
            var listOfMakes = _carmanager.get_all_makes();
            ViewBag.make_list = new SelectList(listOfMakes, "Id", "Name");
            var listofModels = _carmanager.get_all_models();
            ViewBag.model_list = new SelectList(listofModels, "Id", "Name");
            var user_id = User.Identity.GetUserId();

            var carslist = _customermanager.getallcarsbyuserid(user_id);
            NewCarViewModel model = new NewCarViewModel
            {
                carlist = carslist
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Cars(NewCarViewModel model)
        {
            var listOfMakes = _carmanager.get_all_makes();
            ViewBag.make_list = new SelectList(listOfMakes, "Id", "Name");
            var listofModels = _carmanager.get_all_models();
            ViewBag.model_list = new SelectList(listofModels, "Id", "Name");
            var user_id = User.Identity.GetUserId();

            Car car = new Car
            {
                CreatedBy = user_id,
                makeid = model.makeid,
                modelid = model.modelid,
                year = model.year,
                millege = model.millege,
                IsActive = true
            };
            var result = _customermanager.AddNewCar(car);

            var carslist = _customermanager.getallcarsbyuserid(user_id);
            NewCarViewModel newmodel = new NewCarViewModel
            {
                carlist = carslist
            };

            return View(newmodel);
        }

        public JsonResult GetLog(int id)
        {
            var car = _customermanager.GetCarById(id);
            var order = _customermanager.GetOrderByUserandModel(car.CreatedBy, car.modelid);
            foreach (var item in order)
            {
                //orderid=item.Id

            }

            //var detail = _customermanager.GetOrderDetailByOrderIds(order.id);

            return Json(JsonRequestBehavior.AllowGet);
        }



        public ActionResult PendingBookings()
        {
            var user_id = User.Identity.GetUserId();
            var listofbookings = _customermanager.GetAllPendingBookingsById(user_id);
            return View(listofbookings);
        }

        public ActionResult CompletedBookings()
        {
            var user_id = User.Identity.GetUserId();
            var listofbookings = _customermanager.GetAllCompleteBookingsById(user_id);
            return View(listofbookings);
        }

        public ActionResult ViewBooking(int id)
        {
            var order = _customermanager.GetBookingById(id);


            OrderViewModel model = new OrderViewModel
            {
                orderid = order.Id,
                Name = order.Name,
                address = order.Address,
                contact = order.PhoneNo,
                email = order.Email,
                Carmake = order.CarModel.Make.Name,
                CarModel = order.CarModel.Name,
                millage = order.Millage,
                totalprice = order.Price,
                timingslot = order.TimingSlot.StartingTime.ToShortTimeString() + "-" + order.TimingSlot.EndingTime.ToShortTimeString(),
                year = order.Year,
                pricesofsubservices = _customermanager.GetBookingDetailByBookingId(order.Id),
                orderdate = order.CreatedAt,
                status = order.status,
                rating = order.rating
            };

            return View(model);

        }

        public JsonResult UpdateOrder(int id)
        {
            var response = _customermanager.UpdateStatusByOrderId(id);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateOrderRating(int id, int rate)
        {
            var response = _customermanager.UpdateOrderRatingByOrderId(id, rate);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ComplainBox()
        {
            ViewBag.status = "false";
            return View();
        }
        [HttpPost]
        public ActionResult ComplainBox(ComplainViewModel model)
        {
            Complaint com = new Complaint
            {
                complain = model.complain,
                IsActive = true,
                CreatedBy = User.Identity.GetUserId()
            };

            var response = _customermanager.AddComplaint(com);
            if (response == true)
            {
                ViewBag.status = "true";
            }
            return View();
        }


        public JsonResult DeleteOrder(int id)
        {
            var response = _customermanager.DeleteOrder(id);
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Loyalitypoints()
        {

            return View();
        }

    }
}