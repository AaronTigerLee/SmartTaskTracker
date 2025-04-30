using System.Collections.ObjectModel;
using SmartTaskTracker.Model;
using SmartTaskTracker.Service;
using SmartTaskTracker.ViewModel;

namespace SmartTaskTracker.ViewModel;

public class MainPageViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly ToDoService _toDoService;

    // Completed tasks view toggle functionality
    private bool _showCompleted = false;
    public bool ShowCompleted
    {
        get => _showCompleted;
        set
        {
            _showCompleted = value;
            OnPropertyChanged();
            LoadToDosAsync();
        }
    }

    public Command ToggleFilterCommand { get; }
    public Command GetToDosCommand { get; }
    public Command AddToDoCommand { get; }
    public Command EditToDoCommand { get; }
    public Command DeleteToDoCommand { get; }
    public MainPageViewModel(ToDoService toDoService, INavigationService navigationService)
    {
        _toDoService = toDoService;
        _navigationService = navigationService;
        ToggleFilterCommand = new Command(() => ShowCompleted = !ShowCompleted); // switch between true and false for toggle
        AddToDoCommand = new Command(async () => await ExecuteAddToDoCommand());
        EditToDoCommand = new Command<ToDo>(async (toDo) => await ExecuteEditToDoCommand(toDo));
        GetToDosCommand = new Command(async () => await ExecuteGetToDosCommand());
        DeleteToDoCommand = new Command<ToDo>(async (toDo) => await ExecuteDeleteToDoCommand(toDo));
    }

    private async Task ExecuteGetToDosCommand()
    {
        await LoadToDosAsync();
    }
    private async Task ExecuteDeleteToDoCommand(ToDo toDo)
    {
        await DeleteToDoAsync(toDo);
    }

    private async Task ExecuteAddToDoCommand()
    {
        await _navigationService.NavigateToAddToDoPage();
    }

    private async Task ExecuteEditToDoCommand(ToDo toDo)
    {
        await _navigationService.NavigateToEditToDoPage(toDo);
    }



    public ObservableCollection<ToDo> ToDos { get; } = new ObservableCollection<ToDo>();
    private async Task LoadToDosAsync()
    {
        try
        {
            var toDos = await _toDoService.GetToDosAsync();
            ToDos.Clear();

            foreach (var toDo in toDos)
            {
                // Adds tasks that match the filter conditions (complete / incomplete)
                if ((ShowCompleted && toDo.IsCompleted == 1) ||
                    (!ShowCompleted && toDo.IsCompleted == 0))
                {
                    ToDos.Add(toDo);
                }
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Failed to fetch tasks: {ex.Message}", "OK");
        }
    }

    private async Task DeleteToDoAsync(ToDo toDo)
    {
        if (toDo == null)
            return;

        bool confirm = await Application.Current.MainPage.DisplayAlert(
            "Confirm Delete",
            $"Are you sure you want to delete \"{toDo.Name}\"?",
            "Delete", "Cancel");

        if (!confirm) return;

        var success = await _toDoService.DeleteToDoAsync(toDo.Id);

        if (success)
        {
            ToDos.Remove(toDo);
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Failed to delete task...", "OK");
        }
    }

    public async Task MarkToDoCompletedAsync(ToDo toDo)
    {
        var success = await _toDoService.UpdateToDoAsync(toDo);

        if (!success)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Failed to update task status...", "OK");
        }

        await LoadToDosAsync();
    }

}