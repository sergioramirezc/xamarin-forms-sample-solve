using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SR.Xam.Sample.Helpers;
using SR.Xam.Sample.Models.User;
using SR.Xam.Sample.Services.User;
using SR.Xam.Sample.ViewModels.Base;
using Xamarin.Forms;

namespace SR.Xam.Sample.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public UserListViewModel(IUserService userService)
        {
            _userService = userService;
        }

        private ObservableCollection<UserModel> _userList;

        public ObservableCollection<UserModel> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                RaisePropertyChanged(() => UserList);
            }
        }
        public ICommand AboutCommand => new Command(async () => await AboutAsync());

        //About message
        private async Task AboutAsync()
        {
            await DialogService.ShowAlertAsync("Desarrollado por Sergio Ramirez, 04/2018", "Acerca de", "Aceptar");
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            try
            {
                await base.InitializeAsync(null);
                var list = await _userService.GetUserList(1);
                UserList = list.Users.ToObservableCollection();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
