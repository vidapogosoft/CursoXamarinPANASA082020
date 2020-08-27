using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SNGridLayout.Views;

namespace SNGridLayout
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new Home();

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
