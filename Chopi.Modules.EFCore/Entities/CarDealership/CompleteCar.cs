using Chopi.Modules.Share.DataModels;
using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class CompleteCar : Car
    {
        public Guid CompleteId { get; set; }

        public virtual Complete Complete { get; set; }

        public override CarData ConvertToData()
        {
            var carData = new CarCompleteData()
            {
                Id = Id,
                Year = Year,
                BasePrice = BasePrice,
                Color = Color,
                ModelName = Model.Name,
                BrandName = Model.Manufacturer.Brand,
                CarType = WhoIam(),
                CompleteName = Complete.Name
            };

            return carData;
        }

        public override string WhoIam() =>
            "Комплектная";
    }
}
