//using AudioToolbox;
using CheckMate.Resources.ViewModel;
using CheckMate.ViewModels;
using Microsoft.Maui.Controls;

namespace CheckMate.View
{
    public partial class MainPage : ContentPage
    {

        private readonly TasksViewModel _viewModel;

        public MainPage(TasksViewModel viewModel)
        {
            InitializeComponent();

            MainViewModel mainViewModel = new MainViewModel();

            BindingContext = viewModel;

            _viewModel = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadTaskAsync();
        }

        private void OnBtnClicked(object sender, EventArgs e)
        {

        }


    }
}