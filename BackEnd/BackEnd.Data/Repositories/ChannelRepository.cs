using BackEnd.Core;
using BackEnd.Data.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Linq;

namespace BackEnd.Data.Repositories
{
    public class ChannelRepository : IRepository<Channel>
    {
        private readonly BackEndDataContext _backEndDataContext;

        public ChannelRepository(BackEndDataContext backEndDataContext)
        {
            _backEndDataContext = backEndDataContext;
        }
        public Channel Add(Channel entity)
        {
           _backEndDataContext.Channel.Add(entity);
           return entity;
        }

        public IQueryable<Channel> All()
        {
            return _backEndDataContext.Channel;
        }

        public int SaveChanges()
        {
            return _backEndDataContext.SaveChanges();
        }

        public Channel Update(Channel entity)
        {
            throw new NotImplementedException();
        }
    }
}
