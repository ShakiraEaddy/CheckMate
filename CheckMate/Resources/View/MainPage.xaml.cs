using CheckMate.ViewModels;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace CheckMate.View
{
    public partial class MainPage : ContentPage
    {
        private readonly TasksViewModel _viewModel;

        public MainPage(TasksViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadTasksAsync();
        }

        private async Task LoadTasksAsync()
        {
            await _viewModel.LoadTaskAsync(); // Assuming this method exists in TasksViewModel
        }
    }
}