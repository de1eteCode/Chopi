using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using System.Collections.Generic;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class Complete : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Autopart> Autoparts { get; set; }
        public List<CompleteToAutopart> CompleteAutopart { get; set; }
    }
}