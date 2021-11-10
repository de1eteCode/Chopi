using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.Modules.EFCore.Entities.Abstract
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }

        public Guid Id { get; set; }
    }
}
