
using DriveYou_Mobile.Views;
using System;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("MaterialIcons-Regular.ttf", Alias ="RegularMaterial")]
[assembly: ExportFont("MaterialIconsOutlined-Regular.otf", Alias = "RegularMaterialOutlined")]
[assembly: ExportFont("MaterialIconsRound-Regular.otf", Alias = "RegularMaterialRound")]
[assembly: ExportFont("MaterialIconsSharp-Regular.otf", Alias = "RegularMaterialSharp")]

namespace DriveYou_Mobile
{
    public partial class App : Application
    {
        public static CookieContainer cookieContainer = new CookieContainer();
        private static HttpClientHandler handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; },
            UseCookies = true,
            CookieContainer = cookieContainer
        };
        public static HttpClient client = new HttpClient(handler)
        {
            //https://10.0.2.2:5001/api/
            BaseAddress = new Uri("https://10.0.2.2:5001/api/", UriKind.RelativeOrAbsolute)
        };
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            XF.Material.Forms.Material.Use("Material.Configuration");
            MainPage = new AppShell();
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
