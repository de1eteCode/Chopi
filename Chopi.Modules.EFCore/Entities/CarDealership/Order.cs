using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.EFCore.Entities.Identity;
using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership
{
    public class Order : BaseEntity
    {
        public string CodeOrder { get; set; } // aka: Номер заказа
        public int PaidPrice { get; set; }
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }

        public virtual User User { get; set; }
        public virtual Car Car { get; set; }
    }
}
