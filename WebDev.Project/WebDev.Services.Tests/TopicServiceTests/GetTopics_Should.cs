using Moq;
using NUnit.Framework;
using WebDev.Data.Contracts;
using WebDev.Models;

namespace WebDev.Services.Tests.TopicServiceTests
{
    [TestFixture]
    public class GetTopicById_Should
    {

        [Test]
        public void _Call_Repository_GetAll_Property_Exactly_Once()
        {
            //Arrange
            var mockedTopicRepository = new Mock<IRepository<Topic>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var service = new TopicService(mockedTopicRepository.Object, mockedUnitOfWork.Object);
            service.GetTopics();

            //Assert
            mockedTopicRepository.Verify(r => r.GetAll, Times.Once);
        }
    }
}