using BackEnd.Core;
using BackEnd.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Services
{
    public interface IMessageService
    {
            ServiceResult<MessageModel> addMessage(MessageModel message);

            ServiceResult<IEnumerable<MessageModel>> getMessage(string channelName);
    }
}
