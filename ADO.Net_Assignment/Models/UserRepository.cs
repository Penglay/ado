using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO.Net_Assignment.Models
{
    public class UserRepository : IUserRepository
    {
        //
        // GET: /UserRepository/

        private UserDataContext _dataContext;

        //private U

        public IEnumerable<UserModel> GetUser()
        {
            IList<UserModel> UserList = new List<UserModel>();
            var query = from user in _dataContext.Users
                        select user;
            var users = query.ToList();
            foreach (var userData in users)
            {
                UserList.Add(new UserModel()
                    {
                        Id = userData.Id,
                        Name = userData.Name,
                        Email = userData.Email,
                        Age = userData.Age
                    });
            }
            return UserList;
        }

        public UserModel GetUserById(int userId)
        {
            var query = from u in _dataContext.Users
                        where u.Id == userId
                        select u;
            var user = query.FirstOrDefault();
            var model = new UserModel()
            {
                Id = userId,
                Name = user.Name,
                Age = user.Age,
                Email = user.Email
            };
            return model;
        }

        public void InsertUser(UserModel user)
        {
            User userData = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Age = user.Age
            };
            _dataContext.Users.InsertAllOnSubmit(userData);
            _dataContext.SubmitChanges();
        }

    }
}
