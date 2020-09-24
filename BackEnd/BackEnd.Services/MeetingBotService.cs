using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Services
{
    public class MeetingBotService : IMeetingBotService
    {
        private readonly IRepository<Message> _messageRepository;

        public MeetingBotService(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public ServiceResult<MessageModel> RespondMessage(string channelName)
        {
            var entity = new Message
            {
                message = "Reunion Comienza: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                user = "MeetingBot",
                channelName = channelName,
                date = DateTime.Now
            };
            var result = _messageRepository.Add(entity);
            _messageRepository.SaveChanges();
            var message = new MessageModel
            {
                message = "Reunion Comienza: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                user = "MeetingBot",
                channelName = channelName,
                date = DateTime.Now
            };
            Console.WriteLine(message.message);
            return ServiceResult<MessageModel>.SuccessResult(message);
        }

 
    }
}
