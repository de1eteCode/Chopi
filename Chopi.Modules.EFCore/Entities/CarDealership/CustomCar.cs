using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using System.Collections.Generic;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class CustomCar : Car
    {
        public virtual IEnumerable<Autopart> Autoparts { get; set; }
        public List<CustomCarToAutopart> CustomCarAutopart { get; set; }
    }
}
