using Chopi.Modules.Share.DataModels;
using System;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class UpdateCarVM : BaseCUVM
    {
        public UpdateCarVM(CarData data)
        {
            Data = data;
        }

        public override string ErrorOnApply => throw new NotImplementedException();

        public override string Title => "Обновление машины";

        public CarData Data { get; }

        protected override CUStatus Status => CUStatus.Update;

        public override bool IsApply()
        {
            throw new NotImplementedException();
        }
    }
}
