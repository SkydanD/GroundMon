using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class WorkerType : User
    {
        public WorkerType(int userId, string name, int workerId)
            : base(userId, name, workerId, nameof(WorkerType))
        {

        }
    }
}