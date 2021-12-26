using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class CompleteCar : Car
    {
        public Guid CompleteId { get; set; }

        public virtual Complete Complete { get; set; }

        public override string WhoIam() =>
            "Комплектная";
    }
}
