using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using SmartTaskTracker.Model;
using SmartTaskTracker.Service;

namespace SmartTaskTracker.ViewModel
{
    public partial class ToDosViewModel:BaseViewModel
    {
        ToDoService toDoService;
        IConnectivity connectivity;

        public ObservableCollection<ToDo> ToDos { get; } = new();
        public ToDosViewModel(ToDoService toDoService, IConnectivity connectivity)
        {
            this.toDoService = toDoService;
            this.connectivity = connectivity;
            Title = "Task List";
        }
        [RelayCommand]
        async Task GetToDosAsync()
        {
            if (IsBusy) return;
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet issue!", "Check your internet connection", "Ok");
                    return;
                }
                IsBusy = true;
                var toDos = await toDoService.GetToDosAsync();
                if (toDos.Count != 0)
                {
                    ToDos.Clear();
                }
                foreach (var toDo in toDos) { ToDos.Add(toDo); }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Error", "Unable to retrieve tasks at this time.", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
