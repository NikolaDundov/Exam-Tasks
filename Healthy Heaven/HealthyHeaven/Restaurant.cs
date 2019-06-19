using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;
        public string Name { get; set; }

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            Salad target = new Salad(name);
            if (this.data.Contains(target))
            {
                data.Remove(target);
                return true;
            }

            return false;
        }

        //public bool Buy(string name)
        //{
        //    if (this.data.FirstOrDefault(x => x.Name == name) == null)
        //    {
        //        return false;
        //    }

        //    data.Remove(data.FirstOrDefault(x => x.Name == name));
        //    return true;
        //}

        public Salad GetHealthiestSalad()
        {
            return this.data.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
        }

        public string GenerateMenu()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"{this.Name} have {this.data.Count()} salads:");

            foreach (var salad in data)
            {
                text.AppendLine(salad.ToString());

            }
            return text.ToString().TrimEnd();
        }
    }
}
