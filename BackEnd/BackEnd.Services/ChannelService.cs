using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IRepository<Channel> _channelRepository;

        public ChannelService(IRepository<Channel> channelRepository)
        {
            _channelRepository = channelRepository;
        }

        public ServiceResult<ChannelModel> AddChannel(ChannelModel channel)
        {
            var entity = new Channel
            {
                theme = channel.theme,
                name = channel.name
            };
            var result = _channelRepository.Add(entity);
            _channelRepository.SaveChanges();
            channel.id = entity.id;
            return ServiceResult<ChannelModel>.SuccessResult(channel);
        }

        public ServiceResult<IEnumerable<ChannelModel>> GetChannels()
        {
            var result = this._channelRepository.All()
                .Select(x => new ChannelModel
                {
                    theme = x.theme,
                    name = x.name,
                    id = x.id
                }).ToList();
            return ServiceResult<IEnumerable<ChannelModel>>.SuccessResult(result);
        }
    }
}
