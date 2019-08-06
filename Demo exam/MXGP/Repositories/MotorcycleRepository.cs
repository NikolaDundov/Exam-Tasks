using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll() => this.motorcycles.AsReadOnly();

        public IMotorcycle GetByName(string name)
        {
            return motorcycles.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IMotorcycle model)
        {
            return this.motorcycles.Remove(model);
        }
    }
}
