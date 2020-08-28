using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public ServiceResult<UserModel> addUser(UserModel user)
        {
            var entity = new User
            {
                username = user.username,
                name = user.name,
                password = user.password
                
            };
            var result = _userRepository.Add(entity);
            _userRepository.SaveChanges();
            return ServiceResult<UserModel>.SuccessResult(user);
        }

        public ServiceResult<IEnumerable<UserModel>> getUsers()
        {
            var result = this._userRepository.All()
                .Select(x => new UserModel
                {
                    username = x.username,
                    name = x.name,
                    password = x.password

                }).ToList();
            return ServiceResult<IEnumerable<UserModel>>.SuccessResult(result);
        }
    }
}
