using application.Controllers;
using Domain.Dtos.User;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.WhenRequestGet
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível realizar o Get")]
        public async Task Eh_Possivel_Invocar_Controller_Get()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            var userDtoResult = new UserDtoResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreateAt = DateTime.UtcNow
            };

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(userDtoResult);
                        
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
