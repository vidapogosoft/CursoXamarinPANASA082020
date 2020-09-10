using System;
using Xamarin.Forms;
using ZXing;

namespace WifiBarcodeSample
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public void Generate_Barcode(object sender, EventArgs e)
		{
			// TODO Implement error handling and validation
			var security = "";
			var ssidHidden = "";

			switch (Security.SelectedIndex)
			{
				case 0:
					security = "WPA";
					break;
				case 1:
					security = "WEP";
					break;
				default:
					security = "";
					break;
			}

			if (HiddenSsid.IsToggled)
				ssidHidden = "H:true";

			//BarcodeImageView.BarcodeValue = $"WIFI:S:{Ssid.Text};T:{security};P:{Password.Text};{ssidHidden};";

			BarcodeImageView.BarcodeValue = "TIPO DE PAPEL: SUPERCORR MEDIUM\n"
												+ "GRAMAJE: 195 GSM\n"
												+ "ANCHO:235.00 CM\n"
												+ "REEL:76\n"
												+ "SET: 76\n"
												+ "ROLLO: A\n"
												+ "O / P:1384 - 2\n"
												+ "Concora Kg 37.00\n"
												+ "Humedad % 7.13\n"
												+ "Cobb A g / m2 44.00\n"
												+ "Peso Basico g / m2 196.67\n"
												+ "Calibre mm 0.34\n"
												+ "SCT kN m 3.70";

			BarcodeImageView.IsVisible = true;
		}


		public void ShowHidePassword(object sender, EventArgs e)
		{
			Password.IsPassword = !Password.IsPassword;
		}
	}
}