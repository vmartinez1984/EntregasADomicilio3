using EntregasADomicilio.Core.Entidades;
using EntregasADomicilio.ServicioMobile.Servicios;
using Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDePlatillos : ContentPage
    {
        List<Platillo> _platillos;
        public MenuDePlatillos()
        {
            InitializeComponent();
            CargarCategorias();
            CargarPlatillos();
        }

        private async void CargarCategorias()
        {
            List<Categoria> categorias;

            categorias = await App.Repositorio.Categoria.ObtenerTodos();
            categorias.Add(new Categoria { Id = 0, Nombre = "Todas las categorias" });
            Categorias.ItemsSource = categorias;
            Categorias.SelectedIndex = categorias.Count();
        }

        private async void CargarPlatillos()
        {
            List<PlatilloModel> platillos;

            _platillos = await App.Repositorio.Platillo.ObtenerTodos();
            platillos = new List<PlatilloModel>();
            foreach (var item in _platillos)
            {
                platillos.Add(new PlatilloModel
                {
                    Id = item.Id,
                    EstaActivo = item.EstaActivo,
                    Descripcion = item.Descripcion,
                    ImageSource = ImageSource.FromStream(await App.Repositorio.Platillo.ObtenerStreamDeImagen(item.Ruta)),
                    CategoriaId = item.CategoriaId,
                    Categoria = item.Categoria,
                    Precio = item.Precio,
                    Ruta = item.Ruta,
                    ContentType = item.ContentType,
                    FormFile = item.FormFile,
                    ImagenEnBytes = item.ImagenEnBytes,
                    Nombre = item.Nombre,
                    NombreDelArchivo = item.NombreDelArchivo
                });
            }
            ListViewPlatillos.ItemsSource = platillos;
        }

        private void Categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoria categoria;

            categoria = (sender as Picker).SelectedItem as Categoria;
            if (categoria.Id == 0)
                ListViewPlatillos.ItemsSource = _platillos;
            else
                ListViewPlatillos.ItemsSource = _platillos.Where(x => x.CategoriaId == categoria.Id).ToList();
        }

        private void MenuItemAgregarACarrito_Clicked(object sender, EventArgs e)
        {
            List<Platillo> lista;
            Platillo platillo;

            platillo = (sender as MenuItem).CommandParameter as Platillo;
            if (Preferences.ContainsKey("ListaDePlatillos"))
            {
                string json;

                json = Preferences.Get("ListaDePlatillos", string.Empty);
                lista = JsonConvert.DeserializeObject<List<Platillo>>(json);
            }
            else
            {
                lista = new List<Platillo>();
            }
            lista.Add(platillo);

            Preferences.Set("ListaDePlatillos", JsonConvert.SerializeObject(lista));
        }

        private async void MenuItemIrACarrito_Clicked(object sender, EventArgs e)
        {
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new Carrito());
        }

        private void ListViewPlatillos_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        //private async void CargarPortada()
        //{
        //    Func<Stream> stream;

        //    stream = await App.Repositorio.Platillo.ObtenerPortada();
        //    Portada.Source = ImageSource.FromStream(stream);

        //}
    }
}