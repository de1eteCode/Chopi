using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.Share.DataModels;
using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public abstract class Car : BaseEntity
    {
        public DateTime Year { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
        public int BasePrice { get; set; }
        public Guid ModelId { get; set; }

        public virtual Model Model { get; set; }

        public CarData ConvertToData()
        {
            var carData = new CarData
            {
                Id = Id,
                Year = Year,
                BasePrice = BasePrice,
                Color = Color,
                ModelName = Model.Name,
                BrandName = Model.Manufacturer.Brand,
                CarType = WhoIam()
            };

            return carData;
        }

        public abstract string WhoIam();
    }
}
