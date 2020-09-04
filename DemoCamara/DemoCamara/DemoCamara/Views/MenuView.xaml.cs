using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoCamara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();

            BindingContext = new ViewModels.MenuViewModel(Navigation);
        }
    }
}