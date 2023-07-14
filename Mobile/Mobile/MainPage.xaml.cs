using EntregasADomicilio.Core.Entidades;
using Mobile.Views;
using Newtonsoft.Json;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobile
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new MenuLateral();            
            Cliente cliente;
            cliente = ObtenerCliente();
            if( cliente == null)
            {
                this.Detail = new NavigationPage(new InicioDeSesion());
            }
            else
            {
                this.Detail = new NavigationPage(new MenuDePlatillos());
            }
            App.MasterDetailPage = this;
        }

        private Cliente ObtenerCliente()
        {
            Cliente cliente;
            try
            {
                var json = Preferences.Get("cliente", null);
                //Preferences.Set("cliente", "{\"nombre\":\"Nancy \",\"correo\":\"nancy.marin@gmail.com\",\"telefono\":\"5532737357\",\"contrasenia\":\"123456\",\"apellidos\":\"Marín \",\"fechaDeNacimiento\":\"1991-04-01T00:00:00\",\"direcciones\":[{\"calleYNumero\":\"bolívar 438\",\"referencias\":\"edif rojo\",\"codigoPostal\":\"06800\",\"colonia\":\"Obrera\",\"esPrincipal\":true}]}");
                
                cliente = JsonConvert.DeserializeObject<Cliente>(json);
            }
            catch
            {
                cliente = null;
            }

            return cliente;
        }
    }
}
