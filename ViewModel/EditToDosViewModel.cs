using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SmartTaskTracker.Model;
using SmartTaskTracker.Service;
using System.Runtime.CompilerServices;

namespace SmartTaskTracker.ViewModel
{
	public class EditToDosViewModel : BaseViewModel
	{
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

		public EditToDosViewModel(ToDo toDo)
		{
			ToDo = toDo;
			SaveCommand = new Command(async () => SaveChanges());
		}

		private async Task SaveChanges()
		{
			var json = JsonSerializer.Serialize(ToDo);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var httpClient = new HttpClient();

			var response = await httpClient.PutAsync("http://localhost:5257/api/ToDos/{_toDo.Id}", content);

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

		protected void OnPropertyChanged([CallerMemberName] string name = null) =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        
	}
}