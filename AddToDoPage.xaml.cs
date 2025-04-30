using SmartTaskTracker.Service;
using SmartTaskTracker.ViewModel;


namespace SmartTaskTracker;

public partial class AddToDoPage : ContentPage
{
    public AddToDoPage(ToDoService toDoService)
    {
        InitializeComponent();
        BindingContext = new AddToDosViewModel(toDoService);
    }
}