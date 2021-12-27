using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.ApiSignalR;
using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using System.Windows.Input;
using System.Collections.Generic;
using Chopi.DesktopApp.Models.ObjectSorting;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.DesktopApp.Models.Extends;
using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.Interfaces;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelProvidersVM : PageWithPaginatorVM<ProviderData>
    {
        public ControlPanelProvidersVM()
            : base(new ProviderService(), new ProviderSignalR())
        {
            OpenCreateProviderCommand = new RelayCommand(OpenCreateProviders);
            OpenUpdateProviderCommand = new RelayCommand(OpenUpdateProviders);

            Filters = new List<Filter>()
            {
                new Filter("Бренд", "Brand"),
                new Filter("ИНН", "INN"),
                new Filter("Адрес", "Address"),
                new Filter("Телефон", "PhoneNumber"),
                new Filter("Страна", "CountryName"),
            };
        }

        public override string Title => "Поставщики";

        public ICommand OpenUpdateProviderCommand { get; set; }
        public ICommand OpenCreateProviderCommand { get; set; }

        private async void OpenUpdateProviders()
        {
            ProviderData data = SetectedEntity.CopyObj<ProviderData>();

            if (data is null)
            {
                MsgShowError("Не выбран поставщик");
                return;
            }

            var status = await OpenDialog(new UpdateProviderVM(data), new CUProvider());

            if (status == Util.StatusModal.Ok)
            {
                MsgShowInfo("Типа изменено");
            }
        }

        private async void OpenCreateProviders()
        {
            var data = new ProviderData();
            var status = await OpenDialog(new CreateProviderVM(data), new CUProvider());
            if (status == Util.StatusModal.Ok)
            {
                var executer = NetworkClient.GetInstance<IExecuter>();

                MsgShowInfo("Типа добавлено");
            }
        }
    }
}
