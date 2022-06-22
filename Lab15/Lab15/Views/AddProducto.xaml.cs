using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab15.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lab15.Models;
namespace Lab15.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProducto : ContentPage
    {
        ProductoService productoService;
        bool _isUpdate;
        int productoID;
       
        public AddProducto()
        {
            InitializeComponent();
            productoService = new ProductoService();
            _isUpdate = false;
        }
        public AddProducto(Producto obj)
        {
            InitializeComponent();
            productoService = new ProductoService();
            if (obj != null)
            {
                productoID = obj.Codigo;
                txtNombre.Text = obj.Nombre;
                txtFecha.Text = obj.Fecha;
                txtPrecio.Text = obj.Precio;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            Producto obj = new Producto();
            obj.Nombre = txtNombre.Text;
            obj.Fecha = txtFecha.Text;
            obj.Precio = txtPrecio.Text;
            if (_isUpdate)
            {
                obj.Codigo = productoID;
                await productoService.UpdateProducto(obj);
            }
            else
            {
                productoService.InsertProducto(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}

