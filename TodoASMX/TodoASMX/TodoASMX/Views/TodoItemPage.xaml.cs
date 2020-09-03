using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoASMX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        bool isNewItem;

        public TodoItemPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }
    }
}