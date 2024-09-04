using System.Diagnostics;
using Module02Exercise01.View;
using Microsoft.Maui.Networking;

namespace Module02Exercise01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            base.OnStart();
            CheckNetworkConnectivity();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            Debug.WriteLine("The app is in sleep mode.");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Debug.WriteLine("The app has resumed.");
            CheckNetworkConnectivity();
        }

        private async void CheckNetworkConnectivity()
        {
            var current = Connectivity.Current;

            if (current.NetworkAccess == NetworkAccess.Internet)
            {
                //Attempt I-ping yung website if its accessible ig? whahaha
                try
                {
                    using var httpClient = new HttpClient();
                    var result = await httpClient.GetAsync("https://reqbin.com");

                    if (result.IsSuccessStatusCode)
                    {
                        // Navigate to LoginPage if connected
                        MainPage = new NavigationPage(new LoginPage());
                    }
                    else
                    {
                        // Navigate to OfflinePage if ping fails
                        MainPage = new OfflinePage();
                    }
                }
                catch
                {
                    
                    MainPage = new OfflinePage();
                }
            }
            else
            {
                
                MainPage = new OfflinePage();
            }
        }
    }
}