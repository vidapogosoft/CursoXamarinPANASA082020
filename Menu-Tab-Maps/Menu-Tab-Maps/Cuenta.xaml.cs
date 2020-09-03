using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.Maps;

using Plugin.LocalNotifications;

namespace Menu_Tab_Maps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cuenta : TabbedPage
    {
        public Cuenta()
        {
            InitializeComponent();
            InitialPluginLocator();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            CrossLocalNotifications.Current.Show("No Olvides","Registrado tus datos pordras obtener cientos de beneficios.",
                0,DateTime.Now.AddSeconds(5));
        }

        private async void InitialPluginLocator()
        {
            try
            {
                //validar si esta habilitado GPS
                if (!CrossGeolocator.IsSupported)
                {
                    await DisplayAlert("Advertencia", "GPS no habilitado", "Cerrar");
                    return;
                }

                //Servicios de ubicacion estan activados
                if (!CrossGeolocator.Current.IsGeolocationAvailable || !CrossGeolocator.Current.IsGeolocationEnabled)
                {
                    await DisplayAlert("Advertencia", "Servicios de ubicacion no activados", "Cerrar");
                    return;
                }

                //Realizo la geolocalizacion
                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0,0,5), 0.5);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }        
        }

        private void Current_PositionChanged(object sender, PositionEventArgs e)
        {
            //Metodo que obtiene las coordenadas

            //Validar señal GPS
            if (!CrossGeolocator.Current.IsListening)
            {
                DisplayAlert("Advertencia", "No se visualiza coordenadas, GPS no habilitado", "Cerrar");
                return;
            }

            //Muestro las coordenadas en pantalla
            var coordenadas = CrossGeolocator.Current.GetPositionAsync();
            LblAltimetria.Text = coordenadas.Result.Altitude.ToString();
            LblLatitud.Text = coordenadas.Result.Latitude.ToString();
            LblLongitud.Text = coordenadas.Result.Longitude.ToString();

            //Muestrar en el mapa
            MostrarMapa(coordenadas.Result.Latitude, coordenadas.Result.Longitude);

        }

        private void MostrarMapa(double Latitud, double Longitud)
        {

            base.OnAppearing();

            //Posicion en el mapa
            GeoLocal.MoveToRegion(

                MapSpan.FromCenterAndRadius
                (
                   new Xamarin.Forms.Maps.Position(Latitud, Longitud),
                   Distance.FromKilometers(0.5)
                
                ));

            var pos = new Xamarin.Forms.Maps.Position(Latitud, Longitud);

            var Pin = new Pin
            {
                Type = PinType.Place,
                Position = pos,
                Label = "Curso de Xamarin"
            };

            GeoLocal.Pins.Add(Pin);

            //GeoLocal.Pins.Count > 0
            //GeoLocal.Pins.Remove(Pin);
        }
    }

}