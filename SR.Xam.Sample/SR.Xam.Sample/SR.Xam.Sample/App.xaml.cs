using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using SR.Xam.Sample.Services;
using SR.Xam.Sample.ViewModels.Base;
using Xamarin.Forms;

namespace SR.Xam.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitApp();
        }

        private void InitApp()
        {
            ViewModelLocator.RegisterDependencies(true);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            AppCenter.Start("android=c1814787-b3a3-45a6-a413-db78ad6213df;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Crashes));

            await InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
