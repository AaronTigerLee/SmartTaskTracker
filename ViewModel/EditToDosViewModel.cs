using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using SmartTaskTracker.Model;
using SmartTaskTracker.Service;

namespace SmartTaskTracker.ViewModel
{
    public class EditToDosViewModel : BaseViewModel
    {
        private ToDoService _toDoService;
        private ToDo _toDo;
        public ToDo ToDo
        {
            get => _toDo;
            set
            {
                _toDo = value;
                OnPropertyChanged();
            }

        }

        public ObservableCollection<Priority> Priorities { get; } =
            new ObservableCollection<Priority>((Priority[])Enum.GetValues(typeof(Priority)));

        public ICommand SaveCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public EditToDosViewModel(ToDoService toDoService)
        {
            _toDoService = toDoService;
            SaveCommand = new Command(async () => SaveChanges());
        }

        public async void LoadToDoById(int id)
        {
            try
            {
                var toDo = await _toDoService.GetToDoAsync(id);
                if (toDo != null)
                {
                    ToDo = toDo;
                    // Debugging...
                    // await Application.Current.MainPage.DisplayAlert("Debug", $"Loaded ToDo Name: {ToDo?.Name}", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Task not found...", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load Task. {ex.Message}", "OK");
            }
        }


        private async Task SaveChanges()
        {
            var json = JsonSerializer.Serialize(ToDo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            string url = "http://localhost:5257/api/ToDos/" + _toDo.Id;

            var response = await httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert("Success", "Task updated!", "OK");
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Failed to update task...", "OK");
            }

        }

    }
}