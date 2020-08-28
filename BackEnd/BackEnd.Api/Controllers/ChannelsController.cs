using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Core;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelsController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var channelResult = _channelService.getChannels();
            if (channelResult.ResponseCode != ResponseCode.Success)
                return BadRequest(channelResult.Error);
            return Ok(channelResult.Result);
        }

    }
}
