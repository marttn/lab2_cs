using System.Windows.Input;
using lab2_cs.Models;
using lab2_cs.Tools;
using lab2_cs.Tools.Managers;
using lab2_cs.Tools.Navigation;

namespace lab2_cs.ViewModels
{
    internal class PersonInfoViewModel 
    {

        private ICommand _backCommand;
        private ICommand _closeCommand;

        public Person CurrentPerson { get; } = StationManager.CurrentPerson;

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(BackImplementation));
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation));
            }
        }

        
        private void BackImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.CreatePerson);
        }

        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }
    }
}
