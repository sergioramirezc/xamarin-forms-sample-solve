using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Xam.Sample.Helpers;
using SR.Xam.Sample.Models.User;
using SR.Xam.Sample.Services.User;
using SR.Xam.Sample.ViewModels.Base;

namespace SR.Xam.Sample.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        private readonly UserService _userService;

        public UserListViewModel(UserService userService)
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
