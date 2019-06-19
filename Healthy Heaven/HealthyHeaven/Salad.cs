using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;
        public string Name { get; set; }


        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            return products.Sum(x => x.Calories);
        }

        public int GetProductCount()
        {
            return products.Count();
        }

        public void Add(Vegetable product)
        {
            products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");
            foreach (var item in products)
            {
                text.AppendLine(item.ToString());
            }

            return text.ToString().TrimEnd();
        }
    }
}
