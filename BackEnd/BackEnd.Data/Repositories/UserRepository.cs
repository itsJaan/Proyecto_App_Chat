using BackEnd.Core;
using BackEnd.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly BackEndDataContext _backEndDataContext;

        public UserRepository(BackEndDataContext backEndDataContext)
        {
            _backEndDataContext = backEndDataContext;
        }

        public User Add(User entity)
        {
            _backEndDataContext.User.Add(entity);
            return entity;
        }

        public IQueryable<User> All()
        {
            return _backEndDataContext.User;
        }

        public int SaveChanges()
        {
            return _backEndDataContext.SaveChanges();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
