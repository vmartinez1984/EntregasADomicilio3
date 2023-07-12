using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuLateral : ContentPage
    {
        public MenuLateral()
        {
            InitializeComponent();
            if(Preferences.ContainsKey("cliente"))
            {
                BtnIniciarSesion.IsVisible = false;
            }
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            App.MasterDetailPage.IsPresented = false;
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new InicioDeSesion());
        }

        private void BtnCarrito_Clicked(object sender, EventArgs e)
        {
            App.MasterDetailPage.IsPresented = false;
            App.MasterDetailPage.Detail = new NavigationPage(new Carrito());
        }

        private  void BtnMenuDePlatillos_Clicked(object sender, EventArgs e)
        {
            App.MasterDetailPage.IsPresented = false;
            App.MasterDetailPage.Detail = new NavigationPage(new MenuDePlatillos());
        }

        private  void BtnPerfil_Clicked(object sender, EventArgs e)
        {
            App.MasterDetailPage.IsPresented = false;
            //await App.MasterDetailPage.Detail.Navigation.PushAsync(new Registro());                        
            App.MasterDetailPage.Detail = new NavigationPage(new Registro());                        
        }

        private void BtnUltimoPedido_Clicked(object sender, EventArgs e)
        {
            App.MasterDetailPage.IsPresented = false;
            //await App.MasterDetailPage.Detail.Navigation.PushAsync(new Registro());                        
            App.MasterDetailPage.Detail = new NavigationPage(new EstatusDelUltimoPedido());
        }

        private void BtnHistorialDePedidos_Clicked(object sender, EventArgs e)
        {

        }
    }
}