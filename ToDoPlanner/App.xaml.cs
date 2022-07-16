using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToDoPlannerLib;
using ToDoPlannerLib.Interfaces;

using ToDoPlanner.ViewModels;
using ToDoPlanner.Stores;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IToDoService _service;
        private readonly NavigationStore _store;

        public App()
        {
            _store = new NavigationStore();
            var dbName = ToDoPlanner.Properties.Settings.Default.DatabaseName;
            //Deplendency injection:
            var repository = new ToDoPlannerLib.Models.ToDoRepository(dbName);
            _service = new ToDoPlannerLib.Service(repository);
            CreateTasksListViewModel();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_store)
            };
            _store.CurrentViewModel = CreateTasksListViewModel();
            MainWindow.Show();
            //base.OnStartup(e);
        }

        private TasksListViewModel CreateTasksListViewModel()
        {
            return new TasksListViewModel(_service);
        }
    }
}
