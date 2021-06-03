using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using DAL.UnitOfWork;
using System;
using CCL.Security.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Enities;

namespace BLL.Services.Impl
{
    public class WorkerService : IWorkerService
    {
        private readonly IUnitOfWork _database;
        private int workersQty = 10;
        public WorkerService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
        public IEnumerable<WorkerDTO> GetWorkers(int qty)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(AdminType))
            {
                throw new MethodAccessException();
            }
            var workerId = user.WorkerId;
            var workerEntities =
                _database
                .Workers
                .Find(z => z.Id == workerId);
            var mapper =
                new MapperConfiguration(cfg => cfg.CreateMap<Worker, WorkerDTO>()).CreateMapper();
            var workersDTO =
                    mapper
                    .Map<IEnumerable<Worker>, List<WorkerDTO>>(workerEntities);
            return workersDTO;
        }
    }
}