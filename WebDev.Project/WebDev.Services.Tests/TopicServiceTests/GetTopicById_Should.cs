using Moq;
using NUnit.Framework;
using WebDev.Data.Contracts;
using WebDev.Models;

namespace WebDev.Services.Tests.TopicServiceTests
{
    [TestFixture]
    public class GetById_Should
    {

        [TestCase(10)]
        [TestCase(15)]
        [TestCase(50)]
        public void _Call_Repository_GetById_Method_Exactly_Once(int id)
        {
            //Arrange
            var mockedTopicRepository = new Mock<IRepository<Topic>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var service = new TopicService(mockedTopicRepository.Object, mockedUnitOfWork.Object);
            service.GetTopicById(id);

            //Assert
            mockedTopicRepository.Verify(r => r.GetById(id), Times.Once);
        }
    }
}