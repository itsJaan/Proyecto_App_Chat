using BackEnd.Api.Controllers;
using BackEnd.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Test.Builders
{
    public class MessageControllerBuilder
    {
        private IMessageService _defaultMessageService;
        private bool _useDefaultMessageService = true;

        public MessageControllerBuilder WithMessageService(IMessageService messageService)
        {
            _useDefaultMessageService = false;
            _defaultMessageService = messageService;
            return this;
        }

        public MessageController Build()
        {
            if (_useDefaultMessageService)
                _defaultMessageService = GetDefaultMessageService().Object;

            return new MessageController(_defaultMessageService);
        }

        public Mock<IMessageService> GetDefaultMessageService()
        {
            return new Mock<IMessageService>();
        }
    }
}
