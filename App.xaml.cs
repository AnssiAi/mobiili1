namespace harjoitusi
{
    public partial class App : Application
    {
        internal static ViewModels.ExerciseListViewModel? MainViewModel { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            MainViewModel = new();

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await MainViewModel.RefreshItems();
        }
    }
}
