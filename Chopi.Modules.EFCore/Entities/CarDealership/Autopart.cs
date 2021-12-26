using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Chopi.Modules.Share.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public AutopartData ConvertToData()
        {
            var data = new AutopartData();
            data.Id = Id;
            data.Article = Article;
            data.Name = Name;
            data.Description = Description;
            data.Price = Price;
            data.ManufactureName = Manufacturer.Brand;
            
            data.ForModels = new List<string>(Models.Select(e => e.Model.Name));
            return data;
        }
    }
}
