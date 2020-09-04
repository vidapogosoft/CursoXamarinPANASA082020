using Xamarin.Forms;

namespace DemoCamara
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.MenuView());
        }
    }
}
