using System.Linq;
using System.Web.Mvc;
using Postal;
using Autobots.BLL.Manager;
using Autobots.Entities.Models.ViewModels;
using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Identity;

namespace Autobots.Controllers
{
    public class HomeController : Controller
    {
        public OrderManager Ordermanager;
        public ServiceManager ServiceManager;
        public CarManager Carmanager;
        public HomeController()
        {

            Ordermanager = new OrderManager();
            ServiceManager = new ServiceManager();
            Carmanager = new CarManager();
        }

        public ActionResult Index()
        {
            ViewBag.book = "fail";
            ViewBag.order = "false";

            return View();
        }
        [HttpPost]
        public ActionResult Index(Booking booking)
        {
            Booking book = new Booking
            {
                Name = booking.Name,
                Email = booking.Email,
                Number = booking.Number,
                Message = booking.Message,
                CreatedAt = DateTime.UtcNow

            };
            try
            {
                Ordermanager.add_booking(book);
                //RedirectToAction("Index");
            }
            catch (Exception)
            {
                // ignored
            }

            ViewBag.book = "success";
            return View(booking);
        }



        public bool Subscriber(string mail)
        {
            try
            {
                Subscribers sub = new Subscribers
                {
                    Email = mail,
                    CreatedAt = DateTime.Now
                };

                var addEmail = Carmanager.Add_Email(sub);
                dynamic email = new Email("SubscribeEmail");
                email.To = mail;
                email.Subject = "Auto|Bots Subscription";
                email.Send();
                return true;
            }
            catch (Exception)
            {
                // ignored
            }
            return true;
        }
        public bool CallMe(string number)
        {
            var result = ValidatePhoneNumber(number);
            if (result.Item1)
            {
                CallNumbers callnumber = new CallNumbers
                {
                    Number = result.Item2,
                    CreatedAt = DateTime.Now
                };
                Carmanager.Add_Number(callnumber);
                return true;
            }

            return false;
        }


        private Tuple<bool, string> ValidatePhoneNumber(string number)
        {
            if (Regex.Match(number, @"^(\+923[0-9]{9})$").Success)
                return new Tuple<bool, string>(true, "+923" + number.Substring("+923".Length));
            if (Regex.Match(number, @"^(03[0-9]{9})$").Success)
                return new Tuple<bool, string>(true, "+923" + number.Substring("03".Length));
            if (Regex.Match(number, @"^(00923[0-9]{9})$").Success)
                return new Tuple<bool, string>(true, "+923" + number.Substring("00923".Length));
            return new Tuple<bool, string>(false, null);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection collection)
        {
            Booking book = new Booking
            {
                Name = collection["Name"],
                Email = collection["Email"],
                Number = collection["Number"],
                Message = collection["message"],
                CreatedAt = DateTime.UtcNow
            };
            try
            {
                Ordermanager.add_booking(book);
            }
            catch (Exception)
            {
                // ignored
            }
            ViewBag.book = "success";
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
        public ActionResult WhyUs()
        {

            return View();
        }
        public ActionResult Appointment()
        {
            var modelList = Ordermanager.get_all_models();
            var makeList = Ordermanager.get_all_makes();
            ViewBag.models = new SelectList(modelList, "Id", "Name");
            ViewBag.makes = new SelectList(makeList, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Appointment(AppointmentViewModel model)
        {
            var userId = "";
            OrderResponseModel response = new OrderResponseModel();
            var modelList = Ordermanager.get_all_models();
            var makeList = Ordermanager.get_all_makes();
            ViewBag.models = new SelectList(modelList, "Id", "Name");
            ViewBag.makes = new SelectList(makeList, "Id", "Name");
            userId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : null;
            //List<PriceChart> prices = Ordermanager.get_price_by_subserviceId(JArray.Parse(model.selectedsubservices).ToObject<List<int>>());
            if (ModelState.IsValid)
            {
                //  var userid = User.Identity.GetUserId();
                //Get response model for order email
               
                response = Ordermanager.CreateOrder(model, JArray.Parse(model.selectedsubservices).ToObject<List<int>>(), userId);
                //  var result = response;
            }
            return PartialView("_OrderModal", response);
        }
        [HttpPost]
        public JsonResult UpdateOrder(OrderResponseModel model)
        {
            var result = Ordermanager.UpdateOrderbyOrderID(model);
            //Order email send
            //dynamic email = new Email("OrderEmailTemplate");
            //email.To = model.email;
            //email.response = model;
            //email.Subject = "Auto|Bots Order Details";
            //email.Send();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _DropDown(int id)
        {
            var model = Ordermanager.get_model_by_makeId(id).Select(x => new ListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Selected = false
            }).ToList();
            return PartialView("_DropDown", model);
        }
        public PartialViewResult ServiceSelection(int id)
        {
            ViewBag.Service = ServiceManager.GetServices();
            ViewBag.ModelId = id;
            return PartialView("_AppointmentInformation");
        }
        public PartialViewResult TimingsandLocation()
        {
            var timingList = Ordermanager.get_all_timeslots().Select(x => new ListViewModel()
            {
                Id = x.Id,
                Name = x.StartingTime.ToShortTimeString() + " - " + x.EndingTime.ToShortTimeString()
            });
            ViewBag.timeslots = new SelectList(timingList, "Id", "Name");
            return PartialView("_TimingsandLocation");
        }


    }
}