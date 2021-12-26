using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.Share.DataModels;
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

        public ProviderData ConvetToData()
        {
            var data = new ProviderData();
            data.Id = Id;
            data.Brand = Brand;
            data.INN = INN;
            data.Address = Address;
            data.PhoneNumber = PhoneNumber;
            data.CountryName = Country.Name;
            return data;
        }
    }
}
