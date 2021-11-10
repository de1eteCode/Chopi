using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Transits
{
    public class CustomCarToAutopart
    {
        public Guid CustomCarId { get; set; }
        public Guid AutopartId { get; set; }

        public virtual CustomCar CustomCar { get; set; }
        public virtual Autopart Autopart { get; set; }
    }
}
