using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Chopi.DesktopApp.Core
{
    /// <summary>
    /// Котроллер окон: Управление окнами и открытие модальных окон, как самостоятельные.
    /// </summary>
    public class WindowController
    {
        private readonly Dispatcher _dispatcher;

        /// <summary>
        /// Словарь соответствий vm с окнами.
        /// </summary>
        private readonly Dictionary<Type, Type> _vmToWindowMap = new();

        /// <summary>
        /// Словарь открытых окон. Необходим для отслеживания открытых окон. Модальные окна в этот словарь не попадают.
        /// </summary>
        private readonly Dictionary<WindowVM, Window> _openedWindows = new();

        public WindowController()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
        }

        /// <summary>
        /// Регистрация нового соответствия типа vm с типом окна. При регистрации нового соответствия типов необходимо учитывать, что при создании окон,
        /// будет создавать первое зарегистрированное соответствующие окно, так как идентификация окон происход по типу vm.
        /// </summary>
        public void RegisterVMToWindow<VM, Win>()
            where VM : WindowVM
            where Win : Window
        {
            var typeVm = typeof(VM);
            if (typeVm.IsInterface || typeVm.IsAbstract)
                throw new ArgumentException(nameof(typeVm) + " can't to register");

            if (_vmToWindowMap.ContainsKey(typeVm))
                throw new InvalidOperationException(nameof(typeVm) + " is registered");

            _vmToWindowMap[typeVm] = typeof(Win);
        }

        /// <summary>
        /// Создание экземпляра окна с vm в качестве DataContext.
        /// </summary>
        private Window CreateWindowWithVM(WindowVM vm)
        {
            if (!_vmToWindowMap.TryGetValue(vm.GetType(), out Type? windType))
                throw new InvalidOperationException($"For {nameof(vm)} not found window");

            if (windType is null)
                throw new ArgumentNullException(nameof(windType));

            var wind = Activator.CreateInstance(windType);

            if (wind is not null && wind is Window window)
            {
                window.DataContext = vm;
                return window;
            }
            else
                throw new InvalidOperationException(nameof(wind));
        }

        /// <summary>
        /// Отображение нового окна с vm в качестве DataContext.
        /// </summary>
        public void ShowWindow(WindowVM vm)
        {
            if (vm is null)
                throw new ArgumentNullException(nameof(vm));

            if (_openedWindows.ContainsKey(vm))
                throw new InvalidOperationException($"UI for {nameof(vm)} is displayed");

            var window = CreateWindowWithVM(vm);
            _openedWindows[vm] = window;
            window.Show();
        }

        /// <summary>
        /// Закрытие любого окна, связанного с vm.
        /// </summary>
        public void CloseWindow(WindowVM vm)
        {
            if (!_openedWindows.TryGetValue(vm, out Window? wind))
                throw new InvalidOperationException($"UI for this {nameof(vm)} is not displlayed");

            wind.Close(); _openedWindows.Remove(vm);
        }

        /// <summary>
        /// Аоказ окна в модальном окне.
        /// </summary>
        public async Task ShowModal(WindowVM vm)
        {
            if (vm is null)
                throw new ArgumentNullException(nameof(vm));

            var window = CreateWindowWithVM(vm);
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            await window.Dispatcher.InvokeAsync(() => window.ShowDialog());
        }

        /// <summary>
        /// Открывает новое окно, закрыв старое.
        /// </summary>
        /// <param name="new">vm нового окна</param>
        /// <param name="old">vm старого окна (обычно это будет vm, из которой вызывается этот метод)</param>
        public void ShowNewAndCloseOld(WindowVM @new, WindowVM old)
        {
            _dispatcher.Invoke(() =>
            {
                ShowWindow(@new);
                CloseWindow(old);
            });
        }
    }
}
