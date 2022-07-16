using ToDoPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlanner.Stores
{
    internal class NavigationStore
    {
        private readonly Dictionary<string, ViewModelBase> _routes;
        internal NavigationStore()
        {
            _routes = new Dictionary<string, ViewModelBase>();
        }
        internal void Add( string routeName, ViewModelBase view)
        {
            _routes.Add(routeName, view);
        }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;
        public bool Route(string routeName)
        {
            ViewModelBase viewModel;
            if (_routes.TryGetValue(routeName, out viewModel))
            {
                CurrentViewModel = viewModel;
                return true;

            }
            return false;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}