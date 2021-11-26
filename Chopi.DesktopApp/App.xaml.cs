﻿using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.ViewModels;
using Chopi.DesktopApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        }

        public WindowController Controller { get; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Controller.ShowWindow(new AuthVM());
        }
    }
}