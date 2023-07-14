using EntregasADomicilio.Core.Entidades;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiCuenta : ContentPage
    {
        public MiCuenta()
        {
            InitializeComponent();
            ColocarDatos();
        }

        private void ColocarDatos()
        {
            Cliente cliente;

            cliente = JsonConvert.DeserializeObject<Cliente>(Preferences.Get("cliente", string.Empty));
            LabelNombre.Text = cliente.Nombre + " " + cliente.Apellidos;
            LabelCorreo.Text = cliente.Correo;
            BtnTelefono.Text = cliente.Telefono;
        }

        private async void BtnMisPedidos_Clicked(object sender, EventArgs e)
        {
            App.MasterDetailPage.IsPresented = false;
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new HistorialDePedidos());
        }

        private async void BtnMisDirecciones_Clicked(object sender, EventArgs e)
        {
            App.MasterDetailPage.IsPresented = false;
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new Direcciones());
        }

        private async void BtnTelefono_Clicked(object sender, EventArgs e)
        {
            App.MasterDetailPage.IsPresented = false;
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new Telefono());
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Cerrar sesión", "¿Desea cerra la sesión?", "Cerrar sesión", "No"))
            {
                Preferences.Clear();
                App.MasterDetailPage.IsPresented = false;
                App.MasterDetailPage.Detail = new NavigationPage(new InicioDeSesion());
            }
        }

    }//end class
}