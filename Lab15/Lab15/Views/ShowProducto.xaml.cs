using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lab15.Models;
using Lab15.Services;

namespace Lab15.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProducto : ContentPage
    {
        ProductoService productoService;
        public ShowProducto()
        {
            InitializeComponent();
            productoService = new ProductoService();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowProductos();
        }
        private void ShowProductos()
        {
            var res = productoService.GetAllProductos().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddProducto());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Producto obj = (Producto)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        await this.Navigation.PushAsync(new AddProducto(obj));
                        break;
                    case "Eliminar":
                        productoService.DeleteProducto(obj);
                        ShowProductos();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}