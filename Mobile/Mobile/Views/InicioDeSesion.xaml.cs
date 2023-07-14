using EntregasADomicilio.Core.Entidades;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioDeSesion : ContentPage
    {
        public InicioDeSesion()
        {
            InitializeComponent();
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            Cliente cliente;

            cliente = await App.Repositorio.Cliente.IniciarSesion(Correo.Text.Trim(), Contrasenia.Text.Trim());
            if (cliente is null)
            {
                await DisplayAlert("Cliente no registrado", "Correo y/o Contraseña incorrecto(s)", "Ok");
            }
            else
            {
                Preferences.Set("cliente", JsonConvert.SerializeObject(cliente));

                App.MasterDetailPage.IsPresented = false;
                App.MasterDetailPage.Detail = new NavigationPage(new MenuDePlatillos());
            }
        }

        private async void BtnRegistrarse_Clicked(object sender, EventArgs e)
        {
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new Registro());
        }
    }
}