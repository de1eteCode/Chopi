using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chopi.DesktopApp.ViewArea.WindowArea.Views
{
    /// <summary>
    /// Логика взаимодействия для ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        public ModalWindow()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseIfApply(object sender, RoutedEventArgs e)
        {
            var context = (ModalWindowVM)this.DataContext;
            var pagecontext = (ModalPageVM)context.CurrentPage.DataContext;
            var res = pagecontext.IsApply();
            if (res)
            {
                Close(sender, e);
            }
        }
    }
}
