using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Xam.Sample.Helpers;
using SR.Xam.Sample.Models.Common;
using SR.Xam.Sample.Models.User;
using SR.Xam.Sample.Services.RequestProvider;

namespace SR.Xam.Sample.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;

        public UserService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<UserListModel> GetUserList(int page)
        {
            try
            {
                //if has internet connection: call the rest service
                //if not, get offline data
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                {
                    string uri = String.Format(Constants.ApiUri+ "/api/users?per_page={0}", 50);
                    var response = await _requestProvider.GetAsync<UserListModel>(uri);
                    if (response == null)
                    {
                        response = new UserListModel();
                    }
                    return response;
                }
                else
                {
                    return Settings.UserList;
                }
            }
            catch (Exception ex)
            {
                if (Settings.UserList != null)
                {
                    return Settings.UserList;
                }
                else
                {
                    return new UserListModel() { Users = new List<UserModel>() };
                }
            }
        }
    }
}
