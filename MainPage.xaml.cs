using SmartTaskTracker.Model;
using SmartTaskTracker.ViewModel;

namespace SmartTaskTracker
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

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

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}
