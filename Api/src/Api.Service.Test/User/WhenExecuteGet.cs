using System;
using System.Threading.Tasks;
using Domain.Dtos.User;
using Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenExecuteGet : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName ="É possível executar o método GET.")]
        public async Task Eh_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(UserId)).ReturnsAsync(userDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(UserId);
            Assert.NotNull(result); 
            Assert.True(result.Id == UserId);
            Assert.Equal(UserName, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDtoResult)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(UserId);
            Assert.Null(_record);
        }
    }
}
