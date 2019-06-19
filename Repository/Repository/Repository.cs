using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> repository;
        private int id = 0;

        public Repository()
        {
            repository = new Dictionary<int, Person>();
        }

        public void Add(Person person)
        {
            repository.Add(id++, person);
        }

        public Person Get(int id)
        {
            Person toGet = null;
            if (repository.ContainsKey(id))
            {
                toGet = repository[id];
            }
            return toGet;
        }

        public bool Update(int id, Person newPerson)
        {
            bool updated = false;
            if (repository.ContainsKey(id))
            {
                repository.Remove(id);
                repository.Add(id , newPerson);
                updated = true;
            }
            return updated;
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            if (repository.ContainsKey(id))
            {
                deleted = true;
                repository.Remove(id);
            }
            return deleted;
        }

        public int Count
        {
            get => repository.Count();
        }
    }
}
