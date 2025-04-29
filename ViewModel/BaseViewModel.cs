using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTaskTracker.Model;
using SmartTaskTracker.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartTaskTracker.ViewModel
{
    public partial class BaseViewModel: ObservableObject, INotifyPropertyChanged
    {
        public BaseViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Creating public property -- (Title)
        [ObservableProperty]
        string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        public bool IsNotBusy => !isBusy;
    }
}
