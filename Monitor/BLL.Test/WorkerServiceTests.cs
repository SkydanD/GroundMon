using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Enities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BLL.Tests
{
    public class WorkerServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            IUnitOfWork nullUnitOfWork = null;

            Assert.Throws<ArgumentNullException>(() => new WorkerService(nullUnitOfWork));
        }

        [Fact]
        public void GetStreets_UserIsAdmin_ThrowMethodAccessException()
        {
            User user = new WorkerType(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IWorkerService streetService = new WorkerService(mockUnitOfWork.Object);

            Assert.Throws<MethodAccessException>(() => streetService.GetWorkers(1));
        }

        [Fact]
        public void GetWorkers_WorkerFromDAL_CorrectMappingToWorkerDTO()
        {
            // Arrange
            User user = new AdminType(1, "test", 1);
            SecurityContext.SetUser(user);
            var streetService = GetWorkerService();
            var actualStreetDto = streetService.GetWorkers(0).First();

            Assert.True(
                actualStreetDto.Id == 1
                && actualStreetDto.Name == "TestN"
            );
        }


        IWorkerService GetWorkerService()
        {
            var mockContext = new Mock<IUnitOfWork>();

            var expectedWorker = new Worker()
            {
                Id = 1,
                Name = "TestN",
            };
            var mockDbSet = new Mock<IWorkerRepository>();
            mockDbSet
                .Setup(z =>
                z.Find(It.IsAny<Func<Worker, bool>>()))
                .Returns(new List<Worker>() { expectedWorker }
                );
            mockContext
                .Setup(context =>
                context.Workers).Returns(mockDbSet.Object);

            return new WorkerService(mockContext.Object);
        }
    }
}