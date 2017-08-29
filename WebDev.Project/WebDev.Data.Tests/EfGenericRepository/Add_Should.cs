﻿using Moq;
using NUnit.Framework;
using WebDev.Data.Contracts;
using WebDev.Data.Tests.GenericRepository.Tests.Mocks;

namespace PhotoLife.Data.Tests.GenericRepository.Tests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void _Call_DbContext_SetAdded()
        {
            //Arrange
            var mockedDbContext = new Mock<IWebDevEntities>();

            var repository = new GenericRepository<MockedGenericRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<MockedGenericRepositoryType>();

            //Act
            repository.Add(entity.Object);

            //Assert
            mockedDbContext.Verify(mdb => mdb.SetAdded(entity.Object), Times.Once);
        }
    }
}