using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using System.Collections.Generic;

namespace Chopi.Modules.EFCore.Entities.CarDealership.TO
{
    public class Work : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual IEnumerable<Maintenance> Maintenances { get; set; }
        public List<MaintenanceToWork> WorkMaintenance { get; set; }
    }
}
