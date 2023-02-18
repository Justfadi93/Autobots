using Autobots.Entities.DataAccess;
using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.BLL.Manager
{
    public class CarManager
    {
        private DbService _db;
        public CarManager()
        {
            _db = new DbService();
        }

        public List<CarMake> get_all_makes()
        {

            var list = _db.CarMakes.GetAll().Where(x=>x.IsActive.Equals(true)).ToList();
            
            return list;

        }

        public List<CarModel> get_all_models()
        {

            var list = _db.CarModels.GetAll().Where(x => x.IsActive.Equals(true)).ToList();

            return list;

        }
        public List<Service> get_all_services()
        {

            var list = _db.Services.GetAll().Where(x => x.IsActive.Equals(true)).ToList();

            return list;

        }
        public List<SubService> get_all_subservices()
        {

            var list = _db.SubServices.GetAll().Where(x => x.IsActive.Equals(true)).ToList();

            return list;

        }

        public CarMake add_make(CarMake make)
        {

              return _db.CarMakes.Insert(make);
        }
        public CarModel add_model(CarModel model)
        {

            return _db.CarModels.Insert(model);
        }
        public Subscribers Add_Email(Subscribers email)
        {

            return _db.Subscribers.Insert(email);

        }

        public CallNumbers Add_Number(CallNumbers numbers)
        {

            return _db.CallNumbers.Insert(numbers);

        }


        public bool DeleteCarMake(int id)
        {

            var make = _db.CarMakes.Get(id);
            try
            {
                _db.CarMakes.Delete(make);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool DeleteCarModel(int id)
        {

            var model = _db.CarModels.Get(id);
            try
            {
                _db.CarModels.Delete(model);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }




    }
}