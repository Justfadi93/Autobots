using Autobots.BLL.Manager;
using Autobots.Entities.Context;
using Autobots.Entities.Models.DB;
using Autobots.Entities.Models.Defaults;
using Autobots.Entities.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Autobots.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly CarManager _carmanager;
        private readonly PriceManager _pricemanager;
        private readonly AdminDashboardManager _adminDManager;
        private readonly CustomerManager _customermanager;
        
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public DashboardController()
        {
            _carmanager = new CarManager();
            _pricemanager = new PriceManager();
            _adminDManager = new AdminDashboardManager();
            _customermanager = new CustomerManager();
        }
        public DashboardController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            if (User.IsInRole(RolesEnum.Admin.ToString()))
            {
                var ordersStats = _adminDManager.OrdersChart();
                DashboardViewModel model = new DashboardViewModel
                {
                    ListofStats = ordersStats
                };

                return View(model);
            }
            else if (User.IsInRole(RolesEnum.Customer.ToString()))
            {

                return RedirectToAction("Index", "Customer");
            }
            else if (User.IsInRole(RolesEnum.CustomUser.ToString()))
            {
                return RedirectToAction("PendingBookings","Dashboard");

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


        }

        public ActionResult CarMake_Add()
        {
            CarMakeViewModel make = new CarMakeViewModel();
            try
            {
                make = new CarMakeViewModel
                {
                    carmake = _carmanager.get_all_makes()

                };
                return View(make);
            }

            catch (Exception)
            {
                // ignored
            }

            return View(make);

        }
        [HttpPost]
        public ActionResult CarMake_Add(CarMakeViewModel make)
        {
            List<CarMake> list = new List<CarMake>();
            try
            {
                CarMake carmake = new CarMake
                {
                    Name = make.Name,
                    Description = make.Description,
                    CreatedAt = DateTime.Now
                };
                _carmanager.add_make(carmake);
                RedirectToAction("CarMake_Add");
            }
            catch (Exception)
            {
                
            }

            //make = new CarMakeViewModel
            //{
            //    carmake = list
            //};
            //return View(make);
           return RedirectToAction("CarMake_Add");
        }


        public ActionResult CarModel_Add()
        {
            CarModelViewModel model = new CarModelViewModel();
            try
            {
                model = new CarModelViewModel
                {
                    carmodel = _carmanager.get_all_models(),
                };
                var listOfMakes = _carmanager.get_all_makes();
                ViewBag.make_list = new SelectList(listOfMakes, "Id", "Name");
                return View(model);
            }
            catch (Exception)
            {
                // ignored
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult CarModel_Add(CarModelViewModel carmodel)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    var car = new CarModel
                    {
                        Name = carmodel.Name,
                        Description = carmodel.Description,
                        MakeId = carmodel.MakeId,
                        CreatedAt = DateTime.Now

                    };
                    _carmanager.add_model(car);
                    return RedirectToAction("CarModel_Add");
                }

                catch (Exception)
                {
                    // ignored
                }
            }


            return View("CarModel_Add");
        }

        public ActionResult PriceChart()
        {


            //ViewBag.model_list = new SelectList(_carmanager.get_all_models(), "Id", "Name");
            //ViewBag.subservice_list = new SelectList(_carmanager.get_all_subservices(), "Id", "Name");
            //PriceChartViewModel price_list = new PriceChartViewModel
            //{

            //    price_list= _pricemanager.get_full_price_chart(),

            //};

            var result = _pricemanager.get_full_price_chart();

            return View(result);
        }

        public ActionResult PriceChartUpdate(int carId, int serviceId, decimal price)
        {
            try
            {
                _pricemanager.UpdatePriceChart(carId, serviceId, price);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult PriceChart(List<UpdatePriceChart> model)
        {
            //ViewBag.model_list = new SelectList(_carmanager.get_all_models(), "Id", "Name");
            //ViewBag.subservice_list = new SelectList(_carmanager.get_all_subservices(), "Id", "Name");
            //PriceChart price = new PriceChart
            //{
            //    ModelId = model.ModelId,
            //    SubServiceId = model.SubServiceId,
            //    Price = model.Price
            //};
            //_pricemanager.add_Price(price);
            return RedirectToAction("PriceChart");
        }


        //[HttpPost]
        //public ActionResult PriceChart(PriceChartViewModel model)
        //{
        //    ViewBag.model_list = new SelectList(_carmanager.get_all_models(), "Id", "Name");
        //    ViewBag.subservice_list = new SelectList(_carmanager.get_all_subservices(), "Id", "Name");
        //    PriceChart price = new PriceChart
        //    {
        //        ModelId=model.ModelId,
        //        SubServiceId=model.SubServiceId,
        //        Price=model.Price

        //    };

        //    _pricemanager.add_Price(price);

        //    return RedirectToAction("PriceChart");
        //}

        public ActionResult Services()
        {
            var serviceList = _adminDManager.GetAllSerivces();
            ViewBag.listofservices = new SelectList(_adminDManager.GetAllSerivces(), "Id", "Name");

            ServiceViewModel model = new ServiceViewModel
            {

                serviceslist = serviceList

            };
            return View(model);
        }
        [HttpPost]

        public ActionResult Services(ServiceViewModel model)
        {
            ViewBag.listofservices = new SelectList(_adminDManager.GetAllSerivces(), "Id", "Name");

            Service service = new Service
            {
                Name = model.Name,
                Description = model.Description,
                IsAddOn = model.IsAddOn,
                ParentServiceId = model.ParentServiceId,
                IsActive = true,
                IconClass = "flaticon-transport1054",
                Price=model.Price
                
            };

            _adminDManager.AddService(service);
            var serviceList = _adminDManager.GetAllSerivces();


            ServiceViewModel mod = new ServiceViewModel
            {

                serviceslist = serviceList

            };
            return View(mod);
        }


        public ActionResult Complains()
        {
            var complainlist = _adminDManager.GetAllComplains();
            return View(complainlist);
        }

        public ActionResult ViewComplain(int id)
        {
            var complain = _adminDManager.GetComplainById(id);
            return View(complain);

        }

        public ActionResult PendingBookings()
        {
            var listofbookings = _customermanager.GetAllPendingBookings();
            return View(listofbookings);
        }

        public ActionResult ProcessingBookings()
        {
            var listofbookings = _customermanager.GetAllProcessingBookings();
            return View(listofbookings);
        }

        public ActionResult CompletedBookings()
        {
            var listofbookings = _customermanager.GetAllCompleteBookings();
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
                status = order.status
               

            };
            return View(model);

        }


        public ActionResult TimeSlot()
        {
            //var timing_list = _adminDManager.GetAllTimingSlot().Select(x => new ListViewModel()
            //{
            //    Id = x.Id,
            //    Name = x.StartingTime.ToShortTimeString() + " - " + x.EndingTime.ToShortTimeString()
            //});
            //ViewBag.timeslots = new SelectList(timing_list, "Id", "Name");
            var timingList = _adminDManager.GetAllTimingSlot();

            TimeslotViewModel model = new TimeslotViewModel
            {
                timelist = timingList
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult TimeSlot(TimeslotViewModel model)
        {
            TimingSlot time = new TimingSlot
            {
                StartingTime = model.StartingTime,
                EndingTime = model.EndingTime,
                IsActive = true,
                DisplayText = "TimeSlot"
            };

            var result = _adminDManager.AddTimeSlot(time);

            if (result)
            {
                return RedirectToAction("TimeSlot");

            }
            else
            {
                return HttpNotFound("Please try again something is wrong");
            }
            //return RedirectToAction("TimeSlot");
        }


        public JsonResult DeleteTimeSlot(int id)
        {

            var result = _adminDManager.DeleteTimeslot(id);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteService(int id)
        {

            var result = _adminDManager.DeleteService(id);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SubService()
        {
            var subserviceslist = _adminDManager.GetAllSubSerivces();
            ViewBag.listofservices = new SelectList(_adminDManager.GetAllSerivces(), "Id", "Name");

            SubServiceViewModel model = new SubServiceViewModel
            {

                subserviceslist = subserviceslist

            };

            return View(model);
        }
        [HttpPost]
        public ActionResult SubServices(SubServiceViewModel model)
        {
            ViewBag.listofservices = new SelectList(_adminDManager.GetAllSerivces(), "Id", "Name");

            SubService subservice = new SubService
            {

                Name = model.Name,
                Description = model.Description,
                IsActive = true,
                ServiceId = model.serviceid,

            };

            _adminDManager.AddSubService(subservice);
            var subserviceslist = _adminDManager.GetAllSubSerivces();
            ViewBag.listofservices = new SelectList(_adminDManager.GetAllSerivces(), "Id", "Name");



            SubServiceViewModel mod = new SubServiceViewModel
            {

                subserviceslist = subserviceslist

            };

            return View("SubService", mod);
        }
        public JsonResult DeleteSubService(int id)
        {

            var result = _adminDManager.DeleteSubService(id);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateOrdertoProcessing(int id)
        {
            var response = _adminDManager.UpdateStatustoProcessingByOrderId(id);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNewUser()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                userlist = _adminDManager.GetAllCustomUser()

            };

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(AddUserViewModel model)
        {

            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    FirstName = "Fname",
                    LastName = "Lname",
                    Email = model.UserName + "@gmail.com",
                    EmailConfirmed = true,
                    usertype = (int)RolesEnum.CustomUser
                };

                var result = await UserManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "CustomUser");
                    AddUserViewModel model1 = new AddUserViewModel
                    {
                        userlist = _adminDManager.GetAllCustomUser()

                    };
                    return RedirectToAction("AddNewUser");
                }
                //AddErrors(result);
            }

            return View("AddNewUser", model);
        }

        public JsonResult DeleteCarMake(int id)
        {

            var result = _carmanager.DeleteCarMake(id);


            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult DeleteCarModel(int id)
        {

            var result = _carmanager.DeleteCarModel(id);


            return Json(result, JsonRequestBehavior.AllowGet);

        }



        public ActionResult CustomersInfo()
        {
           // ViewBag.totalorders = _adminDManager.GetAllCustomers().Sum(x => x.Appointments.Count);

            AddUserViewModel model = new AddUserViewModel
            {
                userlist = _adminDManager.GetAllCustomers()

            };

            return View(model);
        }


        public JsonResult Discount(decimal price , int orderid)
        {
            var result = _adminDManager.getdiscount(price,orderid);


            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}