using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class CreateAutopartVM : BaseCUVM
    {
        public override string ErrorOnApply => throw new NotImplementedException();

        public override string Title => "Создание детали";

        protected override CUStatus Status => CUStatus.Create;

        public override bool IsApply()
        {
            throw new NotImplementedException();
        }
    }
}
