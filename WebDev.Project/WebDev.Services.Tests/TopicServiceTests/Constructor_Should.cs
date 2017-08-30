using System;
using Moq;
using NUnit.Framework;
using WebDev.Data.Contracts;
using WebDev.Models;

namespace WebDev.Services.Tests.TopicServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {

        [Test]
        public void _Throw_ArgumentNullException_WhenRepository_IsNull()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TopicService(null, mockedUnitOfWork.Object));
        }

        [Test]
        public void _Throw_ArgumentNullException_WhenUnitOfWork_IsNull()
        {
            //Arrange
            var mockedTopicRepository = new Mock<IRepository<Topic>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TopicService(mockedTopicRepository.Object, null));
        }

        [Test]
        public void _NotBeNull_WhenEverything_PassedCorrectly()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedTopicRepository = new Mock<IRepository<Topic>>();

            //Act 
            var TopicService = new TopicService(mockedTopicRepository.Object, mockedUnitOfWork.Object);

            //Assert
            Assert.IsNotNull(TopicService);
        }

        [Test]
        public void _Initializes_AsCorrectInstance_WhenEverything_PassedCorrectly()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedTopicRepository = new Mock<IRepository<Topic>>();

            //Act 
            var TopicService = new TopicService(mockedTopicRepository.Object, mockedUnitOfWork.Object);

            //Assert
            Assert.IsInstanceOf<TopicService>(TopicService);
        }
    }
}