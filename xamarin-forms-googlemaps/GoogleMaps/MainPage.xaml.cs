using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace GoogleMaps
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Use this for multiple pins
            GeneratePins();
            // Use this for a single pin
            //GenerateAPin();
            // Use this to generate a polyline
            //GenerateTrack();
            map.InfoWindowClicked += Map_InfoWindowClicked;
        }

        private void GeneratePins()
        {
            var pins = new List<Pin>
            {
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.87) },
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.77) },
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.97) },
            };

            foreach (var pin in pins)
            {
                // We can use FromBundle, FromStream or FromView
                //pin.Icon = BitmapDescriptorFactory.FromBundle("coffee_pin.png");
                map.Pins.Add(pin);
            }
        }

        private void GenerateAPin()
        {
            var pin = new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.87) };
            map.Pins.Add(pin);
        }

        private void Map_InfoWindowClicked(object sender, InfoWindowClickedEventArgs e)
        {
            DisplayAlert("Map Sample", "This is an awesome message", "Done");
        }

        private void GenerateTrack()
        {
            // map as Xamarin.Forms.GoogleMaps.Map

            var polyline = new Polyline();
            polyline.Positions.Add(new Position(-23.58, -46.77));
            polyline.Positions.Add(new Position(-23.62, -46.87));
            polyline.Positions.Add(new Position(-23.78, -46.97));

            // Add pins just for reference
            var pins = new List<Pin>
            {
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.58, -46.77) },
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.62, -46.87) },
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.78, -46.97) },
            };

            foreach (var pin in pins)
            {
                map.Pins.Add(pin);
            }


            polyline.StrokeColor = Color.Blue;
            polyline.StrokeWidth = 5f;
            polyline.Tag = "POLYLINE"; // Can set any object

            polyline.IsClickable = true;
            polyline.Clicked += (s, e) =>
            {
                // handle click polyline
            };

            map.Polylines.Add(polyline);
        }

    }
}
