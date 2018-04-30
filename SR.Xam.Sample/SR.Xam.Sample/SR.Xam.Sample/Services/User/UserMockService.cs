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
        public async Task<UserListModel> GetUserList(int page)
        {
            return new UserListModel()
            {
                Users = new List<UserModel>()
                {
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                    new UserModel(){ Id = 1, First_name = "", Last_name = "", Avatar = ""},
                }
            };
        }
    }
}
