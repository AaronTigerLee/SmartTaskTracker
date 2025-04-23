using SmartTaskTracker.Model;
using SmartTaskTracker.ViewModel;

namespace SmartTaskTracker
{
    public partial class MainPage : ContentPage
    {

        public MainPage(ToDosViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void OnToDoSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedToDo = e.CurrentSelection.FirstOrDefault() as ToDo;
            if (selectedToDo == null) return;

            await Navigation.PushAsync(new EditToDoPage(selectedToDo));

            ToDosCollection.SelectedItem = null;
        }

    }

}
