using Chopi.Modules.Share.Abstracts;
using System;

namespace Chopi.Modules.Share.DataModels
{
    public class CarData : ObjectConteinered
    {
        public DateTime Year { get; set; }
        public string Color { get; set; }
        public int BasePrice { get; set; }

        // Model
        public string ModelNameName { get; set; }

        // Manufacturer
        public string Brand { get; set; }

        // Country
        public string CountryName { get; set; }
    }
}
