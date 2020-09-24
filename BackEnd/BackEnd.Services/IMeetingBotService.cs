using BackEnd.Core;
using BackEnd.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace BackEnd.Services
{
    public interface IMeetingBotService
    {
        ServiceResult<MessageModel> RespondMessage(string channelName);
    }
}
