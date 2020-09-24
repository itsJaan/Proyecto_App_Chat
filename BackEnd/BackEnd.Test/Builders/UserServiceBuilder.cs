using BackEnd.Core;
using BackEnd.Data.Entities;
using BackEnd.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Test.Builders
{
    public class UserServiceBuilder
    {
        private IRepository<User> _defaultUserRepository;
        private bool _useDefaultRepository;

        public UserServiceBuilder WithCategoryRepository(IRepository<User> userRepository)
        {
            _useDefaultRepository = false;
            _defaultUserRepository = userRepository;
            return this;
        }

        public Mock<IRepository<User>> GetDefaultCategoryRepository() => new Mock<IRepository<User>>();

        public IUserService Build()
        {
            if (_useDefaultRepository)
                _defaultUserRepository = GetDefaultCategoryRepository().Object;

            return new UserService(_defaultUserRepository);
        }
    }
}
