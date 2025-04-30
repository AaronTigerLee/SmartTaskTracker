namespace SmartTaskTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(EditToDoPage), typeof(EditToDoPage));
            Routing.RegisterRoute(nameof(AddToDoPage), typeof(AddToDoPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}
