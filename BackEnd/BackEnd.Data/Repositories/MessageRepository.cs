using BackEnd.Core;
using BackEnd.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Data.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
         private readonly BackEndDataContext _backEndDataContext;

        public MessageRepository(BackEndDataContext backEndDataContext)
        {
            _backEndDataContext = backEndDataContext;
        }

        public Message Add(Message entity)
        {
            _backEndDataContext.Message.Add(entity);
            return entity;
        }

        public IQueryable<Message> All()
        {
            return _backEndDataContext.Message;
        }

        public int SaveChanges()
        {
            return _backEndDataContext.SaveChanges();
        }

        public Message Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
