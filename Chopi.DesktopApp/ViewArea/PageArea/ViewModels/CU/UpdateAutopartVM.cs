using System;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class UpdateAutopartVM : BaseCUVM
    {
        public override string ErrorOnApply => throw new NotImplementedException();

        public override string Title => "Обновление детали";

        protected override CUStatus Status => CUStatus.Update;

        public override bool IsApply()
        {
            throw new NotImplementedException();
        }
    }
}
