using System.Collections.ObjectModel;
using SmartTaskTracker.Model;

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

		public ObservableCollection<Priority> Priorities { get; } = new ObservableCollection<Priority>((Priority[])Enum.GetValues(typeof(Priority)));
	}
}