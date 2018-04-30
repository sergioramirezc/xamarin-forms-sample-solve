using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Xam.Sample.Models.User;

namespace SR.Xam.Sample.Services.User
{
    public class UserMockService : IUserService
    {
        public Task<UserListModel> GetUserList(int page)
        {
            throw new NotImplementedException();
        }
    }
}
