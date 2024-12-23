using MauiApp6.Views;
namespace MauiApp6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            
            Routing.RegisterRoute(nameof(ViewGame), typeof(ViewGame));
        }
    }
}
