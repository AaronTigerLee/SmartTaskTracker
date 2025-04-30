using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SmartTaskTracker.Model
{
    public enum Priority
    {
        Low, Medium, High
    }
    public class ToDo : INotifyPropertyChanged
    {
        [Key]
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }

        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }
        private DateTime _dueDate;
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (_dueDate != value)
                {
                    _dueDate = value;
                    OnPropertyChanged();
                }
            }
        }
        private Priority _priority;
        public Priority Priority
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _isCompleted = 0;
        public int IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChanged();
                }
            }
        }

        // Used just for within this app
        [JsonIgnore]
        public bool Completed
        {
            get => IsCompleted == 1;
            set
            {
                IsCompleted = value ? 1 : 0;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        private DateTime? _completion;
        public DateTime? Completion
        {
            get => _completion;
            set
            {
                if (_completion != value)
                {
                    _completion = value;
                    OnPropertyChanged();
                }
            }
        }
        private DateTime? _creation;
        public DateTime? Creation
        {
            get => _creation;
            set
            {
                if (_creation != value)
                {
                    _creation = value;
                    OnPropertyChanged();
                }
            }
        }
        // add foreign key referencing user IDs once auth is implemented.

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
