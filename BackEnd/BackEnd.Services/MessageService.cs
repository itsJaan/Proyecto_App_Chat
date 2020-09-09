using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;

        public MessageService(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public ServiceResult<MessageModel> addMessage(MessageModel message)
        {
            var entity = new Message
            {
                message = message.message,
                user = message.user,
                channelName = message.channelName,
                date = message.date

            };
            var result = _messageRepository.Add(entity);
            _messageRepository.SaveChanges();
            return ServiceResult<MessageModel>.SuccessResult(message);
        }

        public ServiceResult<IEnumerable<MessageModel>> getMessage(string channelName)
        {
            var result = this._messageRepository.All()
                .Where(x => x.channelName == channelName)
                .Select(x => new MessageModel
                {
                    message = x.message,
                    user = x.user,
                    channelName = x.channelName,
                    date = x.date

                }).ToList();
            return ServiceResult<IEnumerable<MessageModel>>.SuccessResult(result);
        }
    }
}
