using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanner.ViewModels;
using ToDoPlannerLib.Interfaces;

using ToDoPlanner.Stores;

namespace ToDoPlanner.Commands
{
    internal class Route : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly string _routeName;
        public Route(NavigationStore navigationStore, string routeName)
        {
         
            _navigationStore = navigationStore;
            _routeName = routeName;
         }
        public override void Execute(object parameter)
        {
            _navigationStore.Route(_routeName);
        }
    }
}
