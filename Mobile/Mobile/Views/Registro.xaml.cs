using EntregasADomicilio.Core.Dto;
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
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
            Cliente cliente;
            Direccion direccion;

            cliente = ObtenerCliente();
            if(cliente != null)
            {
                Correo.Text = cliente.Correo;
                Contrasenia.Text = cliente.Contrasenia;
                Nombre.Text = cliente.Nombre;
                Apellidos.Text = cliente.Apellidos;
                Telefono.Text = cliente.Telefono;
                FechaDeNacimiento.Date = cliente.FechaDeNacimiento;
                direccion = cliente.Direcciones.Where(x=> x.EsPrincipal).FirstOrDefault();
                CalleYNumero.Text = direccion.CalleYNumero;
                Referencias.Text = direccion.Referencias;
                CodigoPostal.Text = direccion.CodigoPostal;
            }
        }

        private Cliente ObtenerCliente()
        {
            Cliente cliente;
            string json;

            json = Preferences.Get("cliente", string.Empty);
            if (string.IsNullOrEmpty(json))
                cliente = null;
            else
                cliente = JsonConvert.DeserializeObject<Cliente>(json);

            return cliente;
        }

        private async void BtnRegistrarCliente_Clicked(object sender, EventArgs e)
        {
            Cliente cliente;

            cliente = new Cliente
            {
                Correo = Correo.Text,
                Contrasenia = Contrasenia.Text,
                Nombre = Nombre.Text,
                Apellidos = Apellidos.Text,
                Direcciones = ObtenerDireccion(),
                Telefono = Telefono.Text,
                FechaDeNacimiento = FechaDeNacimiento.Date
            };

            cliente.Id = await App.Repositorio.Cliente.Agregar(cliente);
            Application.Current.Properties["cliente"] = cliente;
            await DisplayAlert("Datos registrados", "Datos registrados", "Ok");
            await Navigation.PushAsync(new MenuDePlatillos());
        }

        private List<Direccion> ObtenerDireccion()
        {
            List<Direccion> direcciones;

            direcciones = new List<Direccion> {
                new Direccion {
                    CalleYNumero = CalleYNumero.Text,
                    EsPrincipal = true,
                    Referencias = Referencias.Text,
                    CodigoPostal = CodigoPostal.Text,
                    Colonia = (Colonias.SelectedItem as CodigoPostalDto).Asentamiento
                }
            };

            return direcciones;
        }

        private async void BtnBuscarCodigoPostal_Clicked(object sender, EventArgs e)
        {
            List<CodigoPostalDto> lista;

            lista = await App.Repositorio.CodigoPostal.Obtener(CodigoPostal.Text);
            Colonias.ItemsSource = lista;
            if (lista.Count == 1)
            {
                Colonias.SelectedItem = lista[0];
            }
        }
    }
}