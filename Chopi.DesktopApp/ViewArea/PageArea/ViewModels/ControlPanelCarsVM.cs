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
    internal class ControlPanelCarsVM : PageWithPaginatorVM<CarData>
    {
        public ControlPanelCarsVM() :
            base(new CarService(), new CarSignalR())
        {
            OpenCreateCarCommand = new RelayCommand(OpenCreateCars);
            //OpenUpdateCarCommand = new RelayCommand(OpenUpdateCars);

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

        //public ICommand OpenUpdateCarCommand { get; set; }
        public ICommand OpenCreateCarCommand { get; set; }

        //private async void OpenUpdateCars()
        //{
        //    return;
        //    CarCompleteData data = (CarCompleteData)SetectedEntity.CopyObj<CarData>();

        //    if (data is null)
        //    {
        //        MsgShowError("Не выбрана машина");
        //        return;
        //    }

        //    var status = await OpenDialog(new UpdateCarVM(data), new CUCars());

        //    if (status == Util.StatusModal.Ok)
        //    {
        //        var net = NetworkClient.GetInstance<IExecuter>();
        //        var service = new CarCompleteUpdateService(data);
        //        var result = await net.ExecuteAsync(service);

        //        if (result is null || result.StatusCode != System.Net.HttpStatusCode.OK)
        //        {
        //            MsgShowWarning("В ходе обновления произошла ошибка");
        //            return;
        //        }
        //        else
        //        {
        //            MsgShowInfo($"Автомобиль марки {data.BrandName} обновлен");
        //        }
        //    }
        //}

        private async void OpenCreateCars()
        {
            var data = new CarCompleteData();
            var status = await OpenDialog(new CreateCarVM(data), new CUCars());
            if (status == Util.StatusModal.Ok)
            {
                
                var net = NetworkClient.GetInstance<IExecuter>();
                var service = new CarCompleteAddService(data);
                var result = await net.ExecuteAsync(service);

                if (result is null || result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MsgShowWarning("В ходе добавления произошла ошибка");
                    return;
                }
                else
                {
                    MsgShowInfo($"Автомобиль марки {data.BrandName} добавлен");
                }
            }
        }
    }
}
