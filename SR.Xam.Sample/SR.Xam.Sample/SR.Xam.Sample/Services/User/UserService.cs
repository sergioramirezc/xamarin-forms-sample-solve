using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                UriBuilder builder = new UriBuilder(Constants.ApiUri);
                builder.Path = "api/users";
                builder.Query = String.Format("page={0}", page);
                string uri = builder.ToString();
                var response = await _requestProvider.GetAsync<UserListModel>(uri);
                if (response == null)
                {
                    response = new UserListModel();
                }
                return response;
            }
            catch (Exception ex)
            {
                return new UserListModel();
            }
        }
    }
}
