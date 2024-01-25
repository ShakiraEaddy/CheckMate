using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_App.ViewModel
{

    
    internal partial class CreateTaskViewModel: ObservableObject
    {
        public IRelayCommand GoToHomeCommand { get; }

        [ObservableProperty] private string taskName;
        public CreateTaskViewModel()
        {
            GoToHomeCommand = new RelayCommand(async () => await NavigateToHome());
        }

        [RelayCommand]
        private async Task NavigateToHome()
        {
            await Shell.Current.GoToAsync("MainPage");
        }
    }

}
