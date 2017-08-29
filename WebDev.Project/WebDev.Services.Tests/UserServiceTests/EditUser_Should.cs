using Moq;
using NUnit.Framework;
using WebDev.Data.Contracts;
using WebDev.Models;
using WebDev.Services;

namespace WebDev.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class EditUser_Should
    {
        [TestCase("somefancyid", "branimir", "Branimir", "I am branimir")]
        public void _CallRepository_GetById_Method(
            string id,
            string username,
            string name,
            string description)
        {
            //Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            userService.EditUser(id, username, name, description);

            //Assert            
            mockedRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase("somefancyid", "branimir", "Branimir", "I am branimir")]
        public void _ReturnCorrectly_GetAll_Method(
            string id,
            string username,
            string name,
            string description)
        {
            //Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            userService.EditUser(id, username, name, description);

            //Assert            
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase("somefancyid", "branimir", "Branimir", "I am branimir")]
        public void _ShouldSet_Username_Correctly(
            string id,
            string username,
            string name,
            string description)
        {
            //Arrange
            var mockedUser = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedUser);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            userService.EditUser(id, username, name, description);

            //Assert            
            Assert.AreEqual(username, mockedUser.UserName);
        }

        [TestCase("somefancyid", "branimir", "Branimir", "I am branimir")]
        public void _ShouldSet_Description_Correctly(
           string id,
           string username,
           string name,
           string description)
        {
            //Arrange
            var mockedUser = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedUser);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            userService.EditUser(id, username, name, description);

            //Assert            
            Assert.AreEqual(description, mockedUser.Description);
        }

        [TestCase("somefancyid", "branimir", "Branimir", "I am branimir")]
        public void _ShouldSet_Name_Correctly(
           string id,
           string username,
           string name,
           string description)
        {
            //Arrange
            var mockedUser = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedUser);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            userService.EditUser(id, username, name, description);

            //Assert            
            Assert.AreEqual(name, mockedUser.Name);
        }

        [TestCase("somefancyid", "branimir", "Branimir", "I am branimir")]
        public void _Call_Repository_Update_Method_Correctly(
           string id,
           string username,
           string name,
           string description)
        {
            //Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            userService.EditUser(id, username, name, description);

            //Assert            
            mockedRepository.Verify(r => r.Update(user), Times.Once);
        }

        [TestCase("somefancyid", "branimir", "Branimir", "I am branimir")]
        public void _Call_UnitOfWork_Commit_Method_Correctly(
          string id,
          string username,
          string name,
          string description)
        {
            //Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            userService.EditUser(id, username, name, description);

            //Assert            
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }
    }
}