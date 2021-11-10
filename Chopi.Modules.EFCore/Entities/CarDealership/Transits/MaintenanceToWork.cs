using Chopi.Modules.EFCore.Entities.CarDealership.TO;
using System;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Transits
{
    public class MaintenanceToWork
    {
        public Guid MaintenanceId { get; set; }
        public Guid WorkId { get; set; }

        public virtual Maintenance Maintenance { get; set; }
        public virtual Work Work { get; set; }
    }
}
