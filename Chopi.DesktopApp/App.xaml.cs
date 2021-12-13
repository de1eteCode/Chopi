using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels;
using Chopi.DesktopApp.ViewArea.WindowArea.Views;
using System.Windows;

namespace Chopi.DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Controller = new WindowController();
            Controller.RegisterVMToWindow<AuthVM, AuthWindow>();

            Controller.RegisterVMToWindow<AccountantVM, WorkflowWindow>();
            Controller.RegisterVMToWindow<AdministratorVM, WorkflowWindow>();
            Controller.RegisterVMToWindow<DirectorVM, WorkflowWindow>();
            Controller.RegisterVMToWindow<ManagerVM, WorkflowWindow>();
            Controller.RegisterVMToWindow<SystemAdministratorVM, WorkflowWindow>();
        }

        public WindowController Controller { get; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Controller.ShowWindow(new AuthVM());
        }
    }
}
