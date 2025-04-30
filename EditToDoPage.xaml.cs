//using WinRT.SmartTaskTrackerVtableClasses;
using SmartTaskTracker.ViewModel;

namespace SmartTaskTracker;

[QueryProperty(nameof(ToDoId), "id")]
public partial class EditToDoPage : ContentPage
{
    private int _toDoId;
    public int ToDoId
    {
        get => _toDoId;
        set
        {
            _toDoId = value;
            LoadToDo();
        }
    }
    private readonly EditToDosViewModel _viewModel;
    public EditToDoPage(EditToDosViewModel vm)
    {
        InitializeComponent();


        // This binding context for MVVM. Data manipulation WITHOUT MVVM in comments below.
        _viewModel = vm;
        BindingContext = _viewModel;

        //	_toDo = toDo;

        //	// Priorities are enum values. Create list to create options for drop-down, all values from enums in ToDo class.
        //	PriorityPicker.ItemsSource = Enum.GetValues(typeof(Priority)).Cast<Priority>().ToList();
        //	PriorityPicker.SelectedItem = _toDo.Priority;

        //	// Pre-fill text boxes with selected task details. 
        //	TitleEntry.Text = _toDo.Name;
        //	DescriptionEditor.Text = _toDo.Description;
        //	DueDatePicker.Date = _toDo.DueDate;
        //}

        //private async void OnSaveClicked(object sender, EventArgs e)
        //{
        //	// Create a ToDo object with updated details from input fields. 
        //	_toDo.Name = TitleEntry.Text;
        //	_toDo.Description = DescriptionEditor.Text;
        //	_toDo.DueDate = DueDatePicker.Date;
        //	_toDo.Priority = (Priority)PriorityPicker.SelectedItem;

        //	var json = JsonSerializer.Serialize(_toDo);
        //	var content = new StringContent(json, Encoding.UTF8, "application/json");
        //	var httpClient = new HttpClient();

        //	var response = await httpClient.PutAsync($"http://localhost:5257/api/ToDos/{_toDo.Id}", content);

        //	if (response.IsSuccessStatusCode)
        //	{
        //		await DisplayAlert("Success", "Task Updated!", "OK");
        //		await Navigation.PopAsync();
        //	}
        //	else
        //	{
        //		await DisplayAlert("Error", "Failed to update task...", "OK");
        //	}
    }

    private void LoadToDo()
    {
        if (_toDoId > 0)
        {
            _viewModel.LoadToDoById(_toDoId);
        }

        BindingContext = null;
        BindingContext = _viewModel;

    }

    //public void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    if (query.ContainsKey("Id"))
    //    {
    //        int id = int.Parse(query["Id"].ToString());
    //        _viewModel.LoadToDoById(id);

    //    }
    //}

    // Since a Task ID is passed through routing, we need to define a method that will allow the
    // EditToDoPage to receive information via ID from the API

}