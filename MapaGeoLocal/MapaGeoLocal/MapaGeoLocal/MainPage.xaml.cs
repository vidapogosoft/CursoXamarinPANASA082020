using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Maps;
using Plugin.Geolocator;


namespace MapaGeoLocal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializePluginLocator();
        }

        public void MuestraPosMap(double Latitud, double Longitud)
        {
            base.OnAppearing();
            
            //Colocar posicion en el mapa

            this.MiMapa.MoveToRegion(
                MapSpan.FromCenterAndRadius
                (
                    //new Position(-2.170464, -79.9097209),
                    new Position(Latitud, Longitud),
                    Distance.FromKilometers(0.5)
                 )
                );

            //Makers /Pin 
            //var position = new Position(-2.170464, -79.9097209);
            var position = new Position(Latitud, Longitud);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Curso Xamarin - SIPECOM",
                Address = "GYE - Oficina Matriz"
            };
            MiMapa.Pins.Add(pin);

        }

        private async void InitializePluginLocator()
        {
            try
            {
                if (!CrossGeolocator.IsSupported)
                {
                    await DisplayAlert("Error", "GPS no habilitado", "Cerrar");
                    return;
                }

                if (!CrossGeolocator.Current.IsGeolocationEnabled
                    || !CrossGeolocator.Current.IsGeolocationAvailable)
                {
                    await DisplayAlert("Error", "Geolocalizacion restringida", "Cerrar");
                    return;
                }

                CrossGeolocator.Current.PositionChanged += current_PositionChanged;

                //Especifico El tiempo con que se actualiza las coordenadas

                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 1), 0.5);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

        private void current_PositionChanged(object sender,
            Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            try
            {

                if (!CrossGeolocator.Current.IsListening)
                {
                    DisplayAlert("Advertencia", "No se esta visualizando las coordenadas", "Cerrar");
                    return;
                }

                var position = CrossGeolocator.Current.GetPositionAsync();
                this.Latitud.Text = position.Result.Latitude.ToString();
                this.Longitud.Text = position.Result.Longitude.ToString();
                this.Altimetria.Text = position.Result.Altitude.ToString();

                //Muestro en mapa la posicion Geo - Localizada
                MuestraPosMap(position.Result.Latitude, position.Result.Longitude);
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

    }
}
