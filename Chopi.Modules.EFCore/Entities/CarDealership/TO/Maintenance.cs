using Chopi.Modules.EFCore.Entities.Abstract;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using System;
using System.Collections.Generic;

namespace Chopi.Modules.EFCore.Entities.CarDealership.TO
{
    public class Maintenance : BaseEntity
    {
        public DateTime DateOfRecording { get; set; }
        public DateTime DateOfWork { get; set; }
        public DateTime DateOfEnded { get; set; }
        public Guid CarId { get; set; }
        public Guid StatusId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Status Status { get; set; }
        public virtual IEnumerable<Work> Works { get; set; }
        public List<MaintenanceToWork> MaintenanceWork { get; set; }
    }
}
