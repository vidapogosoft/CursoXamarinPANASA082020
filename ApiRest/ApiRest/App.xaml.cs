using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ApiRest.Model;
using ApiRest.Data;
using ApiRest.Views;

namespace ApiRest
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManager { get; set;}

        public App()
        {
            InitializeComponent();

            TodoManager = new TodoItemManager(new RestServices());

            //MainPage = new MainPage();

            MainPage = new NavigationPage( new TodoListPage());

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
