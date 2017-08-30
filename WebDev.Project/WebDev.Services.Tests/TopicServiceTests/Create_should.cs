using Moq;
using NUnit.Framework;
using WebDev.Data.Contracts;
using WebDev.Models;

namespace WebDev.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class Create_Should
    {

        [TestCase("username", "email", "name", "description", "word")]
        public void _Call_Repository_Add_Method_Exactly_Once(
            string username, 
            string email, 
            string name,
            string description,
            string word)
        {
            //Arrange
            var mockedTopicRepository = new Mock<IRepository<Topic>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var author = new User(username, email, name, description);
            var topic = new Topic(name, word, author);

            //Act
            var service = new TopicService(mockedTopicRepository.Object, mockedUnitOfWork.Object);
            service.Create(topic);

            //Assert
            mockedTopicRepository.Verify(r => r.Add(topic), Times.Once);
        }
    }
}