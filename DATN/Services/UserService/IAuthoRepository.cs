using DATN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Services.UserService
{
    public interface IAuthoRepository
    {
        User Login(string UserName, string Password);
        User CreateUser(User user, string password);
        User GetById(int id);
        IEnumerable<User> GetAll();
        void UpdateUser(User user, string password = null);
        void DeleteUser(int id);
        bool UserExists(string UserName);
    }
}
