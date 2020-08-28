using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TallerModulo1.Views;

namespace TallerModulo1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new Views.Menu();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
