using DAL.EF;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;

namespace DAL.Enities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Test Test { get; set; }



    }
}