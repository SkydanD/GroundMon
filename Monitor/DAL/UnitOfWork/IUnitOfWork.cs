using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITestRepository Tests { get; }
        IWorkerRepository Workers { get; }
        IReagentRepository Reagents { get; }
        void Save();
    }
}
