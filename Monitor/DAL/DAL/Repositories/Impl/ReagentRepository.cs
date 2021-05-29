using DAL.EF;
using DAL.Enities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class ReagentRepository : BaseRepository<Reagent>, IReagentRepository
    {
        internal ReagentRepository(GeoEntContext context)
         : base(context)
        {

        }
    }
}
