using System;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class CreateCarVM : BaseCUVM
    {
        public override string ErrorOnApply => throw new NotImplementedException();

        public override string Title => "Создание машины";

        protected override CUStatus Status => CUStatus.Create;

        public override bool IsApply()
        {
            throw new NotImplementedException();
        }
    }
}
