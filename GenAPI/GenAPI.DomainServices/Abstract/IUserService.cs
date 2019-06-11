using GenAPI.DataLayer;
using GenAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenAPI.DomainServices.Abstract
{
    public interface IUserService
    {
        bool SearchUserByName(string name);
        bool ValidateUserPassword(string userName, string password);
        bool InsertUser(ref User user);
        IEnumerable<User> GetUsers();
    }
}
