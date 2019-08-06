using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public void Add(IRider model)
        {
            riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll() => this.riders.AsReadOnly();

        public IRider GetByName(string name)
        {
            return this.riders.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRider model)
        {
           return riders.Remove(model);
        }
    }
}
