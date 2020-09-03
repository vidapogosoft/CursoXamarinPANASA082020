using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ApiRest.Model;

namespace ApiRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            this.lstItems.ItemsSource = await App.TodoManager.GetTodoItem();

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage(true)
            {
                BindingContext = new TodoItems
                {
                    ID = Guid.NewGuid().ToString()
                }

            }); ;

        }

        private async void lstItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage(false)
            {
                BindingContext = e.SelectedItem as TodoItems
            });


        }
    }
}