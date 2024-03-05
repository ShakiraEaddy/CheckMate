using CheckMate.Data;
using CheckMate.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CheckMate.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly TasksViewModel _tasksViewModel;

        private readonly DatabaseContext _context;

        private ObservableCollection<UserTask> dataCollection = new ObservableCollection<UserTask>();

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        public IRelayCommand GoToCreateTaskCommand { get; }
        public ICommand RefreshCommand { get; }

        public MainViewModel()
        {
            GoToCreateTaskCommand = new RelayCommand(async () => await NavigateToCreateTask());

            RefreshCommand = new Command(Refresh);
        }

        public MainViewModel(TasksViewModel tasksViewModel)
        {
            _tasksViewModel = tasksViewModel;

        }
        public MainViewModel(DatabaseContext context)
        {
            _context = context;
        }
/// <summary>
/// /////////////////////////////////////////////////////////////////////
/// </summary>
        private async void Refresh()
        {
            IsRefreshing = true;

            try
            {
                var newData = await FetchDataFromDatabase();

                dataCollection.Clear();

                foreach (var task in newData) 
                { 
                    dataCollection.Add(task);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error refreshing data: {ex.Message}");
            }
            finally 
            { 
                IsRefreshing = false; 
            }

        }

        private async Task<List<UserTask>> FetchDataFromDatabase()
        {
            var tasks = await _context.GetAllAsync<UserTask>();

            return tasks.ToList();
        }

        [RelayCommand]
        private async Task NavigateToCreateTask()
        {
            await Shell.Current.GoToAsync("CreateTaskPage");
        }
    }
}
