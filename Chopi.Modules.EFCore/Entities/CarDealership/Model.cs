using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using System;
using System.Collections.Generic;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public Guid ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual IEnumerable<Autopart> SupportedAutoparts { get; set; }
        public List<ModelToAutopart> ModelAutopart { get; set; }
    }
}
