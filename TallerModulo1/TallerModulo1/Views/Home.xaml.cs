using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TallerModulo1.Models.Entidades;

namespace TallerModulo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        public List<LocalesAfiliados> AllLocales;

        public Home()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CargarLocalesAFiliados();

        }

        public void CargarLocalesAFiliados()
        {
            AllLocales = new List<LocalesAfiliados>()
            {
                new LocalesAfiliados
                {
                    NombreLocalAfiliado = "Wallmart",
                    ImageUrl = "http://18.218.178.167/imagesemail/walmart.jpg"
                },
                new LocalesAfiliados
                {
                    NombreLocalAfiliado = "Target",
                    ImageUrl = "http://18.218.178.167/imagesemail/target.jpg"
                },
                new LocalesAfiliados
                {
                    NombreLocalAfiliado = "Electrocables",
                    ImageUrl = "http://18.218.178.167/imagesemail/ferre1.jpg"
                }
                
            };

            CLLocales.ItemsSource = AllLocales;
        }


    }
}