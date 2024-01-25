using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate.Resources.ViewModel
{
    public partial class MainViewModel
    {
        public IRelayCommand GoToCreateTaskCommand { get; }

        public MainViewModel()
        {
            GoToCreateTaskCommand = new RelayCommand(async() => await NavigateToCreateTask());
        }

        [RelayCommand]
        private async Task NavigateToCreateTask()
        {
            await Shell.Current.GoToAsync("CreateTaskPage");
        }
    }
}
