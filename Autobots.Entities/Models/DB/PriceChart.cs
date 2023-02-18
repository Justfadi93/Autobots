using System.ComponentModel.DataAnnotations.Schema;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.Models.DB
{
    public class PriceChart : EntityBase
    {
        //public int MakeId { get; set; }
        //[ForeignKey("MakeId")]
        //public CarMake CarMake { get; set; }
        

        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual CarModel CarModel { get; set; }


        public int SubServiceId { get; set; }
        [ForeignKey("SubServiceId")]
        public virtual SubService SubService { get; set; }


        public decimal Price { get; set; }



        //public PriceChart()
        //{
        //    CarModel = new CarModel();
        //    SubService = new SubService();
        //}
       
    }
}