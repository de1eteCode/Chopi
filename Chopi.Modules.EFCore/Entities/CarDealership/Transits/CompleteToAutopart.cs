using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Transits
{
    public class CompleteToAutopart
    {
        public Guid CompleteId { get; set; }
        public Guid AutopartId { get; set; }

        public virtual Complete Complete { get; set; }
        public virtual Autopart Autopart { get; set; }
    }
}
