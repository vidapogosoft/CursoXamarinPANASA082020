using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Maps;

namespace TallerMapas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Colocar posicion en el mapa

            this.MiMapa.MoveToRegion(
                MapSpan.FromCenterAndRadius
                (
                    new Position (-2.170464, -79.9097209),
                    Distance.FromKilometers(0.5)
                 )
                );

            //Makers /Pin 
            var position = new Position(-2.170464, -79.9097209);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Curso Xamarin AFP - Genesis",
                Address = "GYE - Oficina Matriz"
            };
            MiMapa.Pins.Add(pin);
        }
    }
}
