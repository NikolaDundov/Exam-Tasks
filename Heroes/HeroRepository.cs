using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes
{
    public class HeroRepository
    {
        public List<Hero> Heroes { get; set; }

        public HeroRepository()
        {
            Heroes = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            Heroes.Add(hero);
        }

        public void Remove(string heroName)
        {
            Hero toRemove = Heroes.FirstOrDefault(x => x.Name == heroName);
            Heroes.Remove(toRemove);
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero strongest = Heroes.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
            return strongest;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero mostAbility = Heroes.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
            return mostAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero mostIntelligent = Heroes.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
            return mostIntelligent;
        }

        public int Count
        {
            get => Heroes.Count;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            foreach (var item in Heroes)
            {
                text.AppendLine(item.ToString());
            }

            return text.ToString().TrimEnd();
        }
    }
}
