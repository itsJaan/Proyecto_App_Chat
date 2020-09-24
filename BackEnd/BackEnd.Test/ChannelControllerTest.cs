using BackEnd.Api.Controllers;
using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BackEnd.Test
{
    public class ChannelControllerTest
    {
        [Fact]
        public void GetChannel_Return200Ok()
        {
            //arrange
            var serviceMock = new Mock<IChannelService>();
            serviceMock.Setup(c => c.GetChannels())
                .Returns(ServiceResult<IEnumerable<ChannelModel>>.SuccessResult(
                    Enumerable.Empty<ChannelModel>()));

            var controller = new ChannelsController(serviceMock.Object);

            //act
            var response = controller.Get();

            //assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
