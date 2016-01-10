using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net_Assignment.Models
{
    interface IUserRepository
    {
        IEnumerable<UserModel> GetUser();
        UserModel GetUserById(int userId);
        void InsertUser(UserModel user);
        void DeleteUser(int userId);
        void updateUser(UserModel user);
    }
}
