using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class UpdateProviderVM : BaseCUVM
    {
        public override string ErrorOnApply => throw new NotImplementedException();

        public override string Title => "Обновление поставщика";

        protected override CUStatus Status => CUStatus.Update;

        public override bool IsApply()
        {
            throw new NotImplementedException();
        }
    }
}
