using BackEnd.Core;
using BackEnd.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Services
{
    public interface IMessageService
    {
            ServiceResult<MessageModel> AddMessage(MessageModel message);

            ServiceResult<IEnumerable<MessageModel>> GetMessage(string channelName);
    }
}
