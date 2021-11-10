using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Transits
{
    public class ModelToAutopart
    {
        public Guid AutopartId { get; set; }
        public Guid ModelId { get; set; }

        public virtual Autopart Autopart { get; set; }
        public virtual Model Model { get; set; }
    }
}
