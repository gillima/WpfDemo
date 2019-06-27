﻿using System.Linq;
using System.Windows;
using DwgSapLink2.Model;
using DwgSapLink2.ViewModel;

namespace DwgSapLink2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs startup)
        {
            base.OnStartup(startup);

            // parse command line arguments and look for "archive
            var configuration = new Configuration(startup.Args.FirstOrDefault(a => a.ToLowerInvariant().Contains("archive")) != null
                ? ConfigurationType.Archive
                : ConfigurationType.Prepare);

            // create the main window and set data context
            this.MainWindow = new ArchiveView
            {
                DataContext = new MainViewModel(configuration)
            };

            // show the main window
            this.MainWindow.Show();
        }
    }
}
