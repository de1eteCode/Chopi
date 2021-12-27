using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Chopi.Modules.Share.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class CustomCar : Car
    {
        public virtual IEnumerable<CustomCarToAutopart> Autoparts { get; set; }

        public override CarData ConvertToData()
        {
            var carData = new CarCustomData()
            {
                Id = Id,
                Year = Year,
                BasePrice = BasePrice,
                Color = Color,
                ModelName = Model.Name,
                BrandName = Model.Manufacturer.Brand,
                CarType = WhoIam(),
                Autoparts = Autoparts.ToList().Select(e => e.Autopart.ConvertToData())
            };

            return carData;
        }

        public override string WhoIam() =>
            "Заказная";
    }
}
