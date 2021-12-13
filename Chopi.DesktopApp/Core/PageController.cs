using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Chopi.DesktopApp.Core
{
    /// <summary>
    /// Котроллер страниц: Управление страницами внутри одного окна.
    /// Используется в viewmodel для окон
    /// </summary>
    internal class PageController
    {
        /// <summary>
        /// Словарь соответствий vm со страницами.
        /// </summary>
        private readonly Dictionary<Type, Type> _vmToPageMap = new();

        /// <summary>
        /// Словарь созданных страниц. Необходим для отслеживания всех страниц на окне.
        /// </summary>
        private readonly Dictionary<PageVM, Page> _createdPages = new();

        /// <summary>
        /// Регистрация нового соответствия типа vm с типом страницы. При регистрации нового соответствия типов необходимо учитывать, что при создании страниц,
        /// будет создавать первое зарегистрированное соответствующая страница, так как идентификация страниц происход по типу vm. Зарегестрированные страницы попадают
        /// в пулл зарегистрированных страниц для окна
        /// </summary>
        public void RegisterVMToPage<TVm, TPage>()
            where TVm : PageVM
            where TPage : Page
        {
            var typeVm = typeof(TVm);
            if (typeVm.IsInterface || typeVm.IsAbstract)
                throw new ArgumentException(typeVm.Name + " can't to register");

            if (_vmToPageMap.ContainsKey(typeVm))
                throw new InvalidOperationException(typeVm.Name + " is registered");

            _vmToPageMap[typeVm] = typeof(TPage);

        }

        /// <summary>
        /// Регистрация нового соответствия типа vm с типом страницы. При регистрации нового соответствия типов необходимо учитывать, что при создании страниц,
        /// будет создавать первое зарегистрированное соответствующая страница, так как идентификация страниц происход по типу vm. Зарегестрированные страницы попадают
        /// в пулл зарегистрированных и созданных страниц для окна
        /// </summary>
        public void RegisterVMToPageAndCreate<TVm, TPage>()
            where TVm : PageVM
            where TPage : Page
        {
            RegisterVMToPage<TVm, TPage>();

            if (Activator.CreateInstance(typeof(TVm)) is PageVM vm)
            {
                var page = CreatePageWithVm(vm);
                _createdPages[vm] = page;
            }
            else
            {
#if DEBUG
                throw new ArgumentNullException($"{nameof(vm)} is null, where created instance type of {nameof(TVm)}");
#else
                return;
#endif
            }
        }

        /// <summary>
        /// Создание экземпляра страницы с vm в качестве DataContext.
        /// </summary
        private Page CreatePageWithVm(PageVM vm)
        {
            if (!_vmToPageMap.TryGetValue(vm.GetType(), out Type? pageType))
                throw new InvalidOperationException(nameof(vm));

            if (pageType is null)
                throw new ArgumentNullException(nameof(pageType));

            var pag = Activator.CreateInstance(pageType) as Page;

            if (pag is not null && pag is Page page)
            {
                page.DataContext = vm;
                return page;
            }
            else
                throw new InvalidOperationException(nameof(pag));
        }

        /// <summary>
        /// Получение страницы окна
        /// </summary>
        public Page GetPage(PageVM vm)
        {
            if (vm is null)
                throw new ArgumentNullException(nameof(vm));

            if (_createdPages.TryGetValue(vm, out var page))
                return page;

            page = CreatePageWithVm(vm);
            _createdPages[vm] = page;
            return page;
        }

        /// <summary>
        /// Удаление страницы из списка созданных
        /// </summary>
        public void HidePage(PageVM vm)
        {
            if (!_createdPages.TryGetValue(vm, out var page))
                throw new InvalidOperationException(nameof(vm));

            _createdPages.Remove(vm);
        }

        /// <summary>
        /// Получение первой страницы в пуле
        /// </summary>
        public Page GetFirstPage()
        {
            if (_createdPages.Count == 0)
                GetPage((PageVM)Activator.CreateInstance(_vmToPageMap.FirstOrDefault().Key)!);

            return _createdPages.FirstOrDefault().Value;
        }

        /// <summary>
        /// Получение последней страницы в пуле
        /// </summary>
        public Page GetLastPage()
        {
            if (_createdPages.Count == 0)
                GetPage((PageVM)Activator.CreateInstance(_vmToPageMap.LastOrDefault().Key)!);

            return _createdPages.LastOrDefault().Value;
        }
    }
}
