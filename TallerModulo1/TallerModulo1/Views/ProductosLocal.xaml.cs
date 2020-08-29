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
    public partial class ProductosLocal : TabbedPage
    {

        public List<ProductosLocales> AllProductos;

        public ProductosLocal(string IdLocal, string NombreLocal)
        {
            InitializeComponent();
            Cargaproductos();

        }



        public void Cargaproductos()
        {
            AllProductos = new List<ProductosLocales>()
            {
                new ProductosLocales
                {
                    IdProductoLocal = "1",
                    NombreProductoLocal = "Jean levis",
                    ImageUrl = "http://18.218.178.167/imagesemail/Jean.png"
                },
                new ProductosLocales
                {
                    IdProductoLocal = "2",
                    NombreProductoLocal = "Play Station",
                    ImageUrl = "http://18.218.178.167/imagesemail/PlayStation5.png"
                },
                new ProductosLocales
                {
                    IdProductoLocal = "3",
                    NombreProductoLocal = "Multimetro",
                    ImageUrl = "http://18.218.178.167/imagesemail/multimetro.jpg"
                }

            };

            CLProductosLocales.ItemsSource = AllProductos;
        }

    }
}