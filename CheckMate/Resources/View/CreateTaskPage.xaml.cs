using CheckMate.Data;
using CheckMate.ViewModels;


namespace CheckMate_App.View
{
    public partial class CreateTaskPage : ContentPage
    {
        private readonly CreateTaskViewModel _viewModel;

        public CreateTaskPage()
        {
            InitializeComponent();
            var tasksViewModel = new TasksViewModel(new DatabaseContext());
            _viewModel = new CreateTaskViewModel(tasksViewModel);
            BindingContext = _viewModel;
        }

        public CreateTaskPage(CreateTaskViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        private async void OnCreateTaskClicked(object sender, EventArgs e)
        {
            await _viewModel.SaveAndNavigateAsync();
            await Navigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.InitializeAsync();
        }

        // Implement other event handlers as needed
    }
}