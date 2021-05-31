using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.EF;
using DAL.Enities;

namespace DAL.Test
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Test()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<GeoEntContext>()
            .Options;

            var mockContext = new Mock<GeoEntContext>(opt);
            var mockDbSet = new Mock<DbSet<Worker>>();
            mockContext
               .Setup(context =>
                    context.Set<Worker>(
                        ))
               .Returns(mockDbSet.Object);
            var repository = new TestWorkerRepository(mockContext.Object);
            Worker expectedWorker = new Mock<Worker>().Object;
            repository.Create(expectedWorker);
            mockDbSet.Verify(dbSet => dbSet.Add(expectedWorker), Times.Once());
        }
    }
}