using Chopi.Modules.EFCore.Entities.Abstract;
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
    }
}
