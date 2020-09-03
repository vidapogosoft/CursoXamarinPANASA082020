using System;
using TodoASMX.Data;
using TodoASMX.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoASMX
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManager { get; set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new NavigationPage(new TodoListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
