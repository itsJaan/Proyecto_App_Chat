using Hangfire;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Api.Controllers.MeetingBotFunctions;

namespace Sample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingBotController : ControllerBase
    {

        private readonly IMeetingBotService _meetingBotService;

        public MeetingBotController(IMeetingBotService meetingBotService)
        {
            _meetingBotService = meetingBotService;
        }

        [HttpGet("{message},{channelName}")]
        public IEnumerable<string> Get(string message, string channelName)
        {
            
            LuisMeetingBot luis = new LuisMeetingBot();
            SchedulingMeeting scheduler = new SchedulingMeeting();
            
            var resultLuis = luis.ParseMessage(message);
            
            var result = scheduler.Schedule(resultLuis.Result[0],resultLuis.Result[1]);
            
            RecurringJob.AddOrUpdate<IMeetingBotService>(x => _meetingBotService.respondMessage(channelName), result[1]);
            return result;
            
        }
    }
}
