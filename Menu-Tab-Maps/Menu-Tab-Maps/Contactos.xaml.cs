using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

using Xamarin.Forms.OpenWhatsApp;


namespace Menu_Tab_Maps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contactos : ContentPage
    {
        public Contactos()
        {
            InitializeComponent();
            DatosMovil();
        }

        private void DatosMovil()
        {
            DeviceInfor.Text = DeviceInfo.Model;
            DeviceVersion.Text = DeviceInfo.VersionString;
            DeviceName.Text = DeviceInfo.Name;
            DeviceManuf.Text = DeviceInfo.Manufacturer;
        }

        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open("046004000");
        }

        private void BtnSMS_Clicked(object sender, EventArgs e)
        {
            //await Sms.ComposeAsync(new SmsMessage("SMS Curso SINERGIASS de XAMARIN", "0960574445"));

            //Envio de mensaje de wassap

            Chat.Open("+593960574445", "Nuevo Pedido Generado\n"
                + "Fecha y Hora: \n" + DateTime.Now.ToString() + "\n"
                );


        }

        private async void BtnEmail_Clicked(object sender, EventArgs e)
        {
            List<string> reciben;
            reciben = new List<string>();

            reciben.Add("vidapogosoft@hotmail.com");

            var message = new EmailMessage
            {
                Subject = "Curso de Xamarin",
                Body = "Curso dicatdo por la empresa SINERGIASS en al ciudad de GYE",
                To = reciben
                //Cc = reciben
            };

            await Email.ComposeAsync(message);

        }
    }
}