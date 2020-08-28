using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TallerModulo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            MyMenu();
        }


        public void MyMenu()
        {
            Detail = new NavigationPage(new Home());

            List<MenuLateral> menu = new List<MenuLateral>
            {
                new MenuLateral { Page = new Home(), MenuTitle = "Home" },
                new MenuLateral { Page = new Contactenos(), MenuTitle = "Contactenos" }

            };

            ListMenu.ItemsSource = menu;


        }

        public class MenuLateral
        { 
            public string MenuTitle { get; set; }

            public Page Page { get; set; }

        }


    }
}