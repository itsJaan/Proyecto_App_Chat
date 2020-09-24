using BackEnd.Core;
using BackEnd.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace BackEnd.Services
{
    public interface IChannelService
    {
        ServiceResult<ChannelModel> AddChannel(ChannelModel channel);

        ServiceResult<IEnumerable<ChannelModel>> GetChannels();

    }
}
