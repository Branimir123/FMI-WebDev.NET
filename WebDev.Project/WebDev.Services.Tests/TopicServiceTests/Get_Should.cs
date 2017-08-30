using Moq;
using NUnit.Framework;
using WebDev.Data.Contracts;
using WebDev.Models;

namespace WebDev.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class Get_Should
    {

        [TestCase(1, 10, "name", "asc")]
        [TestCase(1, 10, "name", "desc")]
        [TestCase(1, 10, "", "")]
        public void _Call_Repository_GetAll_Property_Exactly_Once(
            int page,
            int size,
            string sortBy,
            string orderBy)
        {
            //Arrange
            var mockedTopicRepository = new Mock<IRepository<Topic>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            
            //Act
            var service = new TopicService(mockedTopicRepository.Object, mockedUnitOfWork.Object);
            service.Get(page, size, sortBy, orderBy);

            //Assert
            mockedTopicRepository.Verify(r => r.GetAll, Times.Once);
        }
    }
}