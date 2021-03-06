﻿using System;
using Moq;
using NUnit.Framework;
using WebDev.Data.Tests.GenericRepository.Tests.Mocks;
using WebDev.Data.Contracts;

namespace PhotoLife.Data.Tests.GenericRepository.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void _Throw_ArgumentNullException_IfDbContext_Null()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GenericRepository<MockedGenericRepositoryType>(null));
        }

        [Test]
        public void _NotThrow_ArgumentNullException_IfDbContext_NotNull()
        {
            //Arrange
            var mockedDbContext = new Mock<IWebDevEntities>();

            //Act & Assert
            Assert.DoesNotThrow(() => new GenericRepository<MockedGenericRepositoryType>(mockedDbContext.Object));
        }

        [Test]
        public void _Initialize_NotNull_IfDbContext_NotNull()
        {
            //Arrange
            var mockedDbContext = new Mock<IWebDevEntities>();

            //Act
            var genericRepository = new GenericRepository<MockedGenericRepositoryType>(mockedDbContext.Object);

            //Assert
            Assert.IsNotNull(genericRepository);
        }


        [Test]
        public void _Initialize_CorrectInstance_IfDbContext_NotNull()
        {
            //Arrange
            var mockedDbContext = new Mock<IWebDevEntities>();

            //Act
            var genericRepository = new GenericRepository<MockedGenericRepositoryType>(mockedDbContext.Object);

            //Assert
            Assert.IsInstanceOf<GenericRepository<MockedGenericRepositoryType>>(genericRepository);
        }
    }
}