using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using System;
using System.Collections.Generic;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class Autopart : BaseEntity
    {
        public string Article { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Guid ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual IEnumerable<ModelToAutopart> Models { get; set; }
        public virtual IEnumerable<CompleteToAutopart> Completes { get; set; }
        public virtual IEnumerable<CustomCarToAutopart> CustomCars { get; set; }
    }
}
