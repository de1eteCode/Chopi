using Chopi.DesktopApp.ViewArea.Util;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;
using System.Threading.Tasks;
using System.Windows;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts
{
    public abstract class PageVM : BaseVM
    {
        public bool IsLoaded { get; set; }

        public abstract string Title { get; }

        /// <summary>
        /// Возникает при открытии страницы, необходимо вызывать базовую реализацию, или изменять значение IsLoaded на true
        /// </summary>
        public virtual void OnLoad()
        {
            IsLoaded = true;
        }

        /// <summary>
        /// Возникает при каждом открытии страницы
        /// </summary>
        public virtual void OnOpen() { }

        /// <summary>
        /// Возникает при каждом закрытии страницы
        /// </summary>
        public virtual void OnClose() { }
    }
}
