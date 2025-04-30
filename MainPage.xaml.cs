using SmartTaskTracker.Model;
using SmartTaskTracker.ViewModel;

namespace SmartTaskTracker
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetToDosCommand.Execute(null);
        }

        private async void OnToDoSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedToDo = e.CurrentSelection.FirstOrDefault() as ToDo;
            if (selectedToDo == null)
                return;
            _viewModel.EditToDoCommand.Execute(selectedToDo);

            ((CollectionView)sender).SelectedItem = null;
        }

        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var todo = (ToDo)checkbox.BindingContext;

            if (todo != null)
            {
                var vm = (MainPageViewModel)BindingContext;
                await vm.MarkToDoCompletedAsync(todo);
            }
        }


    }

}
