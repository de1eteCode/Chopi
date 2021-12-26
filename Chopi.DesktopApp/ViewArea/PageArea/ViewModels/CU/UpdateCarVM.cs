using System;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class UpdateCarVM : BaseCUVM
    {
        public override string ErrorOnApply => throw new NotImplementedException();

        public override string Title => "Обновление машины";

        protected override CUStatus Status => CUStatus.Update;

        public override bool IsApply()
        {
            throw new NotImplementedException();
        }
    }
}
