using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BDSQLite1.Model;

namespace BDSQLite1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditStudent : ContentPage
    {
        public EditStudent()
        {
            InitializeComponent();
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var stdupd = (Student)BindingContext;
                bool acuerdo = await DisplayAlert("Confirmar", "Desea actualizar sus datos?....", "De Acuerdo", "Cancelar");

                if (acuerdo)
                {

                    await App.Database.UpdateStudent(stdupd);

                    await DisplayAlert("Exito", "Datos actualizados en la base de datos", "De Acuerdo");

                }

                await Navigation.PopAsync();


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private async void BtnDel_Clicked(object sender, EventArgs e)
        {

            try
            {
                var stddel = (Student)BindingContext;
                bool acuerdo = await DisplayAlert("Confirmar", "Desea borrar sus datos?....", "De Acuerdo", "Cancelar");

                if (acuerdo)
                {

                    await App.Database.DeleteStudent(stddel);

                    await DisplayAlert("Exito", "Datos borrados en la base de datos", "De Acuerdo");

                    await Navigation.PopAsync();

                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}