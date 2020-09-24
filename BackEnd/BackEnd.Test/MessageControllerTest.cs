using BackEnd.Api.Controllers;
using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Services;
using BackEnd.Test.Builders;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BackEnd.Test
{
    
    public class MessageControllerTest
    {
        [Theory]
        [InlineData("futbol")]
        public void GetMessagebyMessage_ReturnOk(string channel)
        {
            //arrange
            var builder = new MessageControllerBuilder();
            var serviceMock = builder.GetDefaultMessageService();

            serviceMock.Setup(c => c.GetMessage(It.IsAny<string>()))
                .Returns(ServiceResult<IEnumerable<MessageModel>>.SuccessResult(
                    Enumerable.Empty<MessageModel>()));

            var controller = builder.WithMessageService(serviceMock.Object).Build();

            //act
            var response = controller.Get(channel);

            //assert
            Assert.IsType<OkObjectResult>(response);
            var responseModel =
                Assert.IsAssignableFrom<IEnumerable<MessageModel>>((response as OkObjectResult).Value);
            Assert.True(!responseModel.Any());
        }

        [Theory]
        [InlineData("@$")]
        public void GetMessagebyMessage_Return400BadRequest(string message)
        {
            //arrange
            var builder = new MessageControllerBuilder();
            var serviceMock = builder.GetDefaultMessageService();

            serviceMock.Setup(c => c.GetMessage(It.IsAny<string>()))
                .Returns(ServiceResult<IEnumerable<MessageModel>>.ErrorResult(string.Empty));

            var controller = builder.WithMessageService(serviceMock.Object).Build();

            //act
            var response = controller.Get(message);

            //assert
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
