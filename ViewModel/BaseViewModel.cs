using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTaskTracker.Model;
using SmartTaskTracker.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartTaskTracker.ViewModel
{
    public partial class BaseViewModel: ObservableObject
    {
        public BaseViewModel() { }

        // Creating public property -- (Title)
        [ObservableProperty]
        string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        public bool IsNotBusy => !isBusy;
    }
}
