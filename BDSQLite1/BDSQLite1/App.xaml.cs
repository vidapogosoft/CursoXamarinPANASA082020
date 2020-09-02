using BDSQLite1.Interface;
using BDSQLite1.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDSQLite1
{
    public partial class App : Application
    {

        static StudentDB database;

        public static StudentDB Database
        {
            get {

                if (database == null)
                {
                    database = new StudentDB(DependencyService.Get<IStdLocHelper>().GetLocalFilePath("studentdb.db"));
                }

                return database;
            }
        
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
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
