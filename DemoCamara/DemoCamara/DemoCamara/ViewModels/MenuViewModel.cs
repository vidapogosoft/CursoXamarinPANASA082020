using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoCamara.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public MenuViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NavigateCommand = new Command<Type>(async (pageType) => await Navigate(pageType));
        }

        async Task Navigate(Type pageType)
        {
            var page = (Page)Activator.CreateInstance(pageType);
            await Navigation.PushAsync(page);
        }
    }
}
