using SmartTaskTracker.Model;
using SmartTaskTracker.ViewModel;
using SmartTaskTracker.Service;


namespace SmartTaskTracker;

public partial class AddToDoPage : ContentPage
{
	public AddToDoPage(ToDoService toDoService)
	{
		InitializeComponent();
		BindingContext = new AddToDosViewModel(toDoService);
	}
}