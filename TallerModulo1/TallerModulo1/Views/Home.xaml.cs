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
                    IdLocalAfiliado = "1",
                    NombreLocalAfiliado = "Wallmart",
                    ImageUrl = "http://18.218.178.167/imagesemail/walmart.jpg"
                },
                new LocalesAfiliados
                {
                    IdLocalAfiliado = "2",
                    NombreLocalAfiliado = "Target",
                    ImageUrl = "http://18.218.178.167/imagesemail/target.jpg"
                },
                new LocalesAfiliados
                {
                    IdLocalAfiliado = "3",
                    NombreLocalAfiliado = "Electrocables",
                    ImageUrl = "http://18.218.178.167/imagesemail/ferre1.jpg"
                }
                
            };

            CLLocales.ItemsSource = AllLocales;
        }

        private async void CLLocales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {

                bool deacuerdo;

                var NombreLocal = (CLLocales.SelectedItem as LocalesAfiliados)?.NombreLocalAfiliado;
                var IdLocal = (CLLocales.SelectedItem as LocalesAfiliados)?.IdLocalAfiliado;

                deacuerdo = await DisplayAlert("Confirmar", "Seguro de seleccionar la tienda: " + NombreLocal, "De Acuerdo", "Cancelar");

                if (deacuerdo)
                {

                    InfoLocal.IsVisible = true;

                    TxtIdLocal.Text = IdLocal;
                    TxtNombreLocal.Text = NombreLocal;

                }

                //DisplayAlert("Mensaje","Ud ha seleccionado a la tienda: " + NombreLocal, "De Acuerdo");


                //reset de la seleccion
                CLLocales.SelectedItem = null;

            }

        }

        private async void BtnProductos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductosLocal(TxtIdLocal.Text, TxtNombreLocal.Text));
        }
    }
}