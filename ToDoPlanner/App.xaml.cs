using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToDoPlannerLib;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var dbName = ToDoPlanner.Properties.Settings.Default.DatabaseName;
            var service = new ToDoPlannerLib.Service(dbName);
            base.OnStartup(e);
        }
    }
}
