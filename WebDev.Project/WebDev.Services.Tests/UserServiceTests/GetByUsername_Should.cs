using Moq;
using NUnit.Framework;
using WebDev.Data.Contracts;
using WebDev.Models;

namespace WebDev.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class GetByUsername_Should
    {
        [TestCase("branimiri")]
        [TestCase("not_branimiri")]
        public void _CallRepository_GetAll_Method(string username)
        {
            //Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            userService.GetUserByUsername(username);

            //Assert            
            mockedRepository.Verify(r => r.GetAll, Times.Once);
        }
    }
}