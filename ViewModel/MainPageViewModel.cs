using System.Collections.ObjectModel;
using SmartTaskTracker.Model;
using SmartTaskTracker.Service;
using SmartTaskTracker.ViewModel;

namespace SmartTaskTracker.ViewModel;

public class MainPageViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly ToDoService _toDoService;
    public Command GetToDosCommand { get; }
    public Command AddToDoCommand { get; }
    public Command EditToDoCommand { get; }
    public MainPageViewModel(ToDoService toDoService, INavigationService navigationService)
    {
        _toDoService = toDoService;
        _navigationService = navigationService;
        AddToDoCommand = new Command(async () => await ExecuteAddToDoCommand());
        EditToDoCommand = new Command<ToDo>(async (toDo) => await ExecuteEditToDoCommand(toDo));
        GetToDosCommand = new Command(async () => await ExecuteGetToDosCommand());

    }

    private async Task ExecuteGetToDosCommand()
    {
        await LoadToDosAsync();
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
                ToDos.Add(toDo);
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Failed to fetch tasks: {ex.Message}", "OK");
        }
    }
}