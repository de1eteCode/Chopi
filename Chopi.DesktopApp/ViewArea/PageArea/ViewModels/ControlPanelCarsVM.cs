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

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelCarsVM : PageWithPaginatorVM<CarData>
    {
        public ControlPanelCarsVM() :
            base(new CarService(), new CarSignalR())
        {
            OpenCreateCarCommand = new RelayCommand(OpenCreateCars);
            OpenUpdateCarCommand = new RelayCommand(OpenUpdateCars);

            Filters = new List<Filter>()
            {
                new Filter("Год", "Year"),
                new Filter("Цвет", "Color"),
                new Filter("Цена", "BasePrice"),
                new Filter("Модель", "ModelName"),
                new Filter("Бренд", "BrandName"),
                new Filter("Страна", "CountryName")
            };
        }

        public override string Title => "Автомобили";

        public ICommand OpenUpdateCarCommand { get; set; }
        public ICommand OpenCreateCarCommand { get; set; }

        private async void OpenUpdateCars()
        {

        }

        private async void OpenCreateCars()
        {

        }
    }
}
