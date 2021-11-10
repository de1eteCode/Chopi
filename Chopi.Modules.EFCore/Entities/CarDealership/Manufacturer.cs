using Chopi.Modules.EFCore.Entities.Abstract;
using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class Manufacturer : BaseEntity
    {
        public string Brand { get; set; }
        public string INN { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
