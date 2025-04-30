using SmartTaskTracker.Model;

namespace SmartTaskTracker.Service
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAddToDoPage()
        {
            await Shell.Current.GoToAsync(nameof(AddToDoPage));
        }

        public async Task NavigateToEditToDoPage(ToDo toDo)
        {
            var route = $"{nameof(EditToDoPage)}?id={toDo.Id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
