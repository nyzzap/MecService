using GenAPI.DAO.Repository.Abstract;
using GenAPI.DataLayer.Abstract;
using GenAPI.Domain.Entities;
using GenAPI.DomainServices.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenAPI.Services.Concrete
{
    public class UserService: IUserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository _repo) {
            this.userRepository = _repo;
        }

        public bool ValidateUserPassword(string userName, string password) => this.userRepository.Get(a => a.Username == userName && a.Password == password,null,"").Any();

        public bool InsertUser(ref User user) {          
            this.userRepository.Insert(ref user);
            return this.userRepository.Save();
        }
        public bool SearchUserByName(string username) => this.userRepository.Get(a => a.Username == username, null, "").Any();
        public IEnumerable<User> GetUsers() => this.userRepository.Get(null, null, "");
        
    }
}
