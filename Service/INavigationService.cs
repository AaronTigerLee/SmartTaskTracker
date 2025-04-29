using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTaskTracker.Model;

namespace SmartTaskTracker.Service
{
    public interface INavigationService
    {
        Task NavigateToAddToDoPage();
        Task NavigateToEditToDoPage(ToDo toDo);
    }
}
