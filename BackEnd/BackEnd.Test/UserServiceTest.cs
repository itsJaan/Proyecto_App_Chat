using BackEnd.Api.Controllers;
using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BackEnd.Test
{
    public class UserServiceTest
    {
        [Fact]
        public void GetUsers_Return200Ok()
        {
            //arrange
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(c => c.getUsers())
                .Returns(ServiceResult<IEnumerable<UserModel>>.SuccessResult(
                    Enumerable.Empty<UserModel>()));

            var controller = new UsersController(serviceMock.Object);
            
            //act
            var response = controller.Get();
            
            //assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
