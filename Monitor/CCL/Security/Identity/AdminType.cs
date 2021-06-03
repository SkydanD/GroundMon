using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class AdminType : User
    {
        public AdminType(int userId, string name, int workerId)
            : base(userId, name, workerId, nameof(AdminType))
        {

        }
    }
}