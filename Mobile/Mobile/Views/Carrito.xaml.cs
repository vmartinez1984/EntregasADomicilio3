using EntregasADomicilio.Core.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carrito : ContentPage
    {
        public Carrito()
        {
            InitializeComponent();

            ColocarPlatillos();
            ColocarTotal();
            ColocarFormasDePago();
            ColocarDireccion();
        }

        private void ColocarDireccion()
        {
            Cliente cliente;
            Direccion direccion;

            cliente = ObtenerCliente();
            direccion = cliente.Direcciones.Where(x => x.EsPrincipal).FirstOrDefault();
            Direccion.Text = $"{direccion.CalleYNumero}, {direccion.Referencias}, {direccion.Colonia}";
        }

        private void ColocarPlatillos()
        {
            List<Platillo> platillos;

            platillos = ObtenerPlatillos();
            ListViewPlatillos.ItemsSource = platillos;
        }

        private void ColocarFormasDePago()
        {
            List<string> formasDePago = new List<string>();
            formasDePago.Add("Efectivo");
            formasDePago.Add("Terminal");
            FormaDePago.ItemsSource = formasDePago;
        }

        private void ColocarTotal()
        {
            Total.Text = $"Total $ {ObtenerPlatillos().Sum(x=>x.Precio)}";
        }

        private List<Platillo> ObtenerPlatillos()
        {
            string json;
            List<Platillo> platillos;

            json = Preferences.Get("ListaDePlatillos", string.Empty);
            platillos = JsonConvert.DeserializeObject<List<Platillo>>(json);
            if(platillos == null)
                platillos= new List<Platillo>();

            return platillos;
        }

        private void MenuItemQuitarDelCarrito_Clicked(object sender, System.EventArgs e)
        {
            List<Platillo> platillos;
            Platillo platillo;
            Platillo platilloAQuitar;

            platillo = (sender as MenuItem).CommandParameter as Platillo;
            platillos = ObtenerPlatillos();
            platilloAQuitar = platillos.FirstOrDefault(x=> x.Id == platillo.Id);
            platillos.Remove(platilloAQuitar);

            Preferences.Set("ListaDePlatillos", JsonConvert.SerializeObject(platillos));
            ListViewPlatillos.ItemsSource = platillos;
            ColocarTotal();
        }

        private async void BtnEnviarPedido_Clicked(object sender, System.EventArgs e)
        {
            Pedido pedido;

            pedido = new Pedido
            {
                ClienteId = ObtenerCliente().Id,
                Comentario = Comentarios.Text,
                DetalleDelPedido = ObtenerDetalleDelPedido()
            };
            BtnEnviarPedido.IsEnabled = false;
            BtnEnviarPedido.Text = "Enviando, espere un momento";
            var data = await App.Repositorio.Pedido.Agregar(pedido);
            BtnEnviarPedido.Text = "Enviar pedido";
            BtnEnviarPedido.IsEnabled = true;

            Preferences.Remove("ListaDePlatillos");
            Preferences.Set("PedidoId",data.ToString());

            await DisplayAlert("Pedido", "Pedido registrado en tienda numero: " + data, "Ok");
        }

        private List<DetalleDelPedido> ObtenerDetalleDelPedido()
        {
            List<Platillo> platillos;
            List<DetalleDelPedido> detalleDelPedidos;

            detalleDelPedidos = new List<DetalleDelPedido>();
            platillos = ObtenerPlatillos();
            platillos.ForEach(o =>
            {
                detalleDelPedidos.Add(new DetalleDelPedido
                {
                    PlatilloId = o.Id,
                    Precio = o.Precio
                });
            });

            return detalleDelPedidos;
        }

        private Cliente ObtenerCliente()
        {
            string json;
            Cliente cliente;

            json = Preferences.Get("cliente", string.Empty);
            cliente = JsonConvert.DeserializeObject<Cliente>(json);

            return cliente;
        }

        private void ListViewPlatillos_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}