using DAL.Enities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Test
{
    class TestWorkerRepository : BaseRepository<Worker>
    {
        public TestWorkerRepository(DbContext context) : base(context)
        {
        }
    }
}