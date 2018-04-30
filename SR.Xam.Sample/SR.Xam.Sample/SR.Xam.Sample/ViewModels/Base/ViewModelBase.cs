using SR.Xam.Sample.Helpers;
using SR.Xam.Sample.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SR.Xam.Sample.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        private bool _isBusy;
        private bool _isConnecting = false;
        private bool _isConnected = true;

        public ICommand TryConnectCommand => new Command(async () => await TryConnectAsync());

        private async Task TryConnectAsync()
        {
            if (_isConnecting) { return; }

            try
            {
                _isConnecting = true;
                IsBusy = true;
                IsConnected = await ConnectivityHelper.CheckConnectivityAsync();
            }
            catch
            {

            }
            finally
            {
                IsBusy = false;
                _isConnecting = false;
            }
        }

        public string ConnectionText
        {
            get { return IsConnected ? "Conectado" : "Desconectado"; }
        }


        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                RaisePropertyChanged(() => IsConnected);
                RaisePropertyChanged(() => IsNotConnected);
                RaisePropertyChanged(() => ConnectionText);
            }
        }

        public bool IsNotConnected
        {
            get { return !IsConnected; }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public ViewModelBase()
        {
            DialogService = ViewModelLocator.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            IsConnected = true;
            _isConnected = true;
        }

        public virtual async Task InitializeAsync(object navigationData)
        {
            IsConnected = true;
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                IsConnected = (await ConnectivityHelper.CheckConnectivityAsync());
            };

            IsConnected = true;
            IsConnected = await ConnectivityHelper.CheckConnectivityAsync();
        }
    }
}