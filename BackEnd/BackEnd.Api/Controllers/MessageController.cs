using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult Post(MessageModel message)
        {
            var messageResult = _messageService.addMessage(message);
            if (messageResult.ResponseCode != ResponseCode.Success)
                return BadRequest(messageResult.Error);
            return Ok(messageResult.Result);
        }

        [HttpGet("{channelName}")]
        public IActionResult Get(string channelName)
        {
            var messageResult = _messageService.getMessage(channelName);
            if (messageResult.ResponseCode != ResponseCode.Success)
                return BadRequest(messageResult.Error);
            return Ok(messageResult.Result);
        }
    }
}
