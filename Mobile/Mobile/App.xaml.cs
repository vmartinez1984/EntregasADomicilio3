using EntregasADomicilio.ServicioMobile.Servicios;
using Xamarin.Forms;

namespace Mobile
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetailPage { get; set; }

        public static Repositorio Repositorio { get; set; }

        public App()
        {
            InitializeComponent();
            Repositorio = new Repositorio();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
