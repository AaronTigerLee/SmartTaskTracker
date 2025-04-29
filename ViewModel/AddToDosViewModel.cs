using System.Collections.ObjectModel;
using SmartTaskTracker.Model;
using SmartTaskTracker.Service;
using Windows.Security.Cryptography.Core;
using System.Text.Json;

namespace SmartTaskTracker.ViewModel;

public class AddToDosViewModel : BaseViewModel
{

    // Create an empty task
    private ToDo _newToDo = new ToDo
    {
        DueDate = DateTime.Now,
        Priority = Priority.Medium
    };
    public ToDo NewToDo
    {
        get => _newToDo;
        set
        {
            _newToDo = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Priority> Priorities { get; }
    = new ObservableCollection<Priority>(Enum.GetValues<Priority>());

    // This save command will be bound to a "Save" button on the UI
    public Command SaveCommand { get; }

    // Service interface (for dependency injection), precludes need to instantiate binding context in XAML
    private readonly ToDoService _toDoService;
    public AddToDosViewModel(ToDoService toDoService)
    {
        _toDoService = toDoService;
        SaveCommand = new Command(async () => await SaveToDo());
    }

    private async Task SaveToDo()
    {
        if (string.IsNullOrWhiteSpace(NewToDo.Name))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Task name is required.", "OK");
            return;
        }

        var success = await _toDoService.CreateToDoAsync(NewToDo);

        //debugging...
        var json = JsonSerializer.Serialize(NewToDo, new JsonSerializerOptions { WriteIndented = true });
        await Application.Current.MainPage.DisplayAlert("JSON Sent: ", json, "OK");

        if (success)
        {
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Task creation failed...", "OK");
        }
    }


}