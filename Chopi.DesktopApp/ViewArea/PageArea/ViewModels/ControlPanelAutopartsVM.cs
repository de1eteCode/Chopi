using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.ApiSignalR;
using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.DesktopApp.Models.Extends;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.Models.ObjectSorting;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelAutopartsVM : PageWithPaginatorVM<AutopartData>
    {
        public override string Title => "Авто детали";

        public ControlPanelAutopartsVM()
            : base(new AutopartService(), new AutopartSignalR())
        {
            OpenCreateAutopartCommand = new RelayCommand(OpenCreateAutopart);
            OpenUpdateAutopartCommand = new RelayCommand(OpenUpdateAutopart);

            Filters = new List<Filter>()
            {
                new Filter("Артикль", "Article"),
                new Filter("Наименование", "Name"),
                new Filter("Описание", "Description"),
                new Filter("Цена", "Price"),
                new Filter("Производитель", "ManufactureName"),
                new Filter("Модель", "ForModelsStr")
            };
        }

        public ICommand OpenUpdateAutopartCommand { get; set; }
        public ICommand OpenCreateAutopartCommand { get; set; }

        private async void OpenUpdateAutopart()
        {
            AutopartData data = SetectedEntity.CopyObj<AutopartData>();

            if (data is null)
            {
                MsgShowError("Не выбран деталь");
                return;
            }

            var result = await OpenDialog(new UpdateAutopartVM(), new CUAutopart());
        }

        private async void OpenCreateAutopart()
        {
            var result = await OpenDialog(new CreateAutopartVM(), new CUAutopart());
        }
    }
}
