using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using System;
using System.Collections.Generic;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class Complete : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<CompleteToAutopart> Autoparts { get; set; }
    }
}