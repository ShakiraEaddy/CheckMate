using CheckMate.Data;
using CheckMate.ViewModels;
//using CheckMate_App.ViewModel;

namespace CheckMate_App.View;

public partial class CreateTaskPage : ContentPage
{
    private readonly CreateTaskViewModel vm;

    //private readonly TasksViewModel _viewModel;

    int timeLeftInSeconds;
    Timer timer;

    public CreateTaskPage()
    {
        InitializeComponent();

        vm = new CreateTaskViewModel(new DatabaseContext());
        
        BindingContext = vm;

       // var databaseContext = new DatabaseContext();

       // _viewModel = new TasksViewModel(databaseContext);
    }

    public CreateTaskPage(CreateTaskViewModel viewModel)
    {

        InitializeComponent();
        vm = viewModel;

        // CreateTaskViewModel createTaskViewModel = new CreateTaskViewModel();

       // vm = new CreateTaskViewModel(viewModel);

        BindingContext = vm;

       // BindingContext = createTaskViewModel;
    }

    private async void OnCreateTaskClicked(object sender, EventArgs e)
    {
        await vm.SaveAndNavigateAsync();
        await Navigation.PopAsync();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadTaskAsync();
    }

    public void OnCheckBoxCheckedChange(object sender, CheckedChangedEventArgs e)
    {
        //When checkbox is interacted with change whether or not the box is checked
        if(IsEnabled != true)
        {
            // Keep completion time hidden
        }
        else if (IsEnabled == false) 
        { 
            // Display Completion time field
        }
    }

    private void Timer_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(int.TryParse(e.NewTextValue, out int hours))
        {
            int totalSeconds = hours * 36;

            if(int.TryParse(e.NewTextValue, out int minutes)) 
            {
                totalSeconds += minutes * 60;
            }

            if(int.TryParse(e.NewTextValue, out int seconds))
            {
                totalSeconds += seconds;
            }
            timeLeftInSeconds = totalSeconds;
            timer = new Timer(OnTimerElapsed, null, 0, 1000);
        }

        else
        {
            //Handle invalid input
        }

    }

    private void OnTimerElapsed(object state)
    {
        timeLeftInSeconds--;

        if(timeLeftInSeconds <= 0) 
        { 
            timer.Dispose();

            //When the timer reaches 0 have a notification sent to the user that the time is up.
        }
        else
        {
            // Update the UI with the new time
            
        }
    }

    private void Date_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime selectedDate = e.NewDate;
        //Handle the selected date accordingly
    }
}
