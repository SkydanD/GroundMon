using DAL.EF;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enities
{
    public class Test
    {
        public int Id { get; set; }
        public string Res { get; set; }
        public virtual Reagent Reagent { get; set; }
        public virtual Worker Worker { get; set; }

    }
}
