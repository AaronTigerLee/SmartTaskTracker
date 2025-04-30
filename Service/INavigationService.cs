using SmartTaskTracker.Model;

namespace SmartTaskTracker.Service
{
    public interface INavigationService
    {
        Task NavigateToAddToDoPage();
        Task NavigateToEditToDoPage(ToDo toDo);
    }
}
