using CheckMate.Data;
using CheckMate.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CheckMate.ViewModels
{
    public class CreateTaskViewModel : ObservableObject
    {
        private readonly TasksViewModel _tasksViewModel;

        // Commands
        public IRelayCommand SaveAndNavigateCommand { get; }
        public IRelayCommand GoToHomeCommand { get; }

        // Properties
        public ObservableCollection<UserTask> Tasks => _tasksViewModel.Tasks;

        // Property to expose OperatingTask
        public UserTask OperatingTask
        {
            get => _tasksViewModel.OperatingTask;
            set => _tasksViewModel.OperatingTask = value;
        }

        private int _selectedPriorityIndex;
        public int SelectedPriorityIndex
        {
            get => _selectedPriorityIndex;
            set
            {
                SetProperty(ref _selectedPriorityIndex, value);
                // Map selected index to priority level and set the Priority property of the UserTask
                if (OperatingTask != null)
                {
                    if (value == 0)
                        OperatingTask.Priority = 1; // High priority
                    else if (value == 1)
                        OperatingTask.Priority = 2; // Average priority
                    else if (value == 2)
                        OperatingTask.Priority = 3; // Low priority
                }
            }
        }

        public CreateTaskViewModel(TasksViewModel tasksViewModel)
        {
            _tasksViewModel = tasksViewModel ?? throw new ArgumentNullException(nameof(tasksViewModel));

            SaveAndNavigateCommand = new RelayCommand(async () => await SaveAndNavigateAsync());
            GoToHomeCommand = new RelayCommand(async () => await NavigateToHome());
        }

        public async Task InitializeAsync()
        {
            await _tasksViewModel.LoadTaskAsync();
        }

        public async Task SaveAndNavigateAsync()
        {
            await _tasksViewModel.SaveAndNavigateAsync();
        }

        private async Task NavigateToHome()
        {
            // Navigate to home page
        }
    }
}
