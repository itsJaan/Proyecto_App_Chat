using BackEnd.Core;
using BackEnd.Core.Models;
using BackEnd.Data.Entities;
using BackEnd.Test.Builders;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BackEnd.Test
{
    public class UserServiceTest
    {
        [Theory]
        [InlineData("Usertest","Juana","juana123")]
        public void Add_ValidCategoryDescription_Succeeds(string username,string name, string password)
        {
            //arrange
            var expected = new UserModel
            {
                username = username,
                name = name,
                password = password
            };

            var builder = new UserServiceBuilder();
            var mock = builder.GetDefaultCategoryRepository();
            mock.Setup(r => r.Add(It.IsAny<User>()))
                .Returns(new User
                {
                    username = username,
                    name = name,
                    password = password
                });
            mock.Setup(r => r.SaveChanges())
                .Returns(1);

            var service = builder.WithCategoryRepository(mock.Object).Build();

            //act
            var result = service.AddUser(expected);

            //assert
            Assert.Equal(ResponseCode.Success, result.ResponseCode);
            Assert.Equal(username, result.Result.username);
            Assert.Equal(name, result.Result.name);
            Assert.Equal(password, result.Result.password);
        }
    }
}
