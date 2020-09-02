using BDSQLite1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BDSQLite1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var Toolbaritem = new ToolbarItem
            {   
                Text = "Nuevo (+)"
            };

            Toolbaritem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new AddStudent()
                {
                    BindingContext = new Student()
                });  
            };

            ToolbarItems.Add(Toolbaritem);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            this.StdList.ItemsSource = await App.Database.GetStudents();

        }

        private async void StdList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditStudent()
                {
                    BindingContext = e.SelectedItem as Student
                });
            }

        }
    }
}
