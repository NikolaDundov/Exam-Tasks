using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> Gladiators;
        private string Name;

        public int Count
        {
            get => Gladiators.Count;
        }

        public Arena(string name)
        {
            this.Name = name;
            Gladiators = new List<Gladiator>();
        }

        public void Add(Gladiator gladiator)
        {
            Gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator toBeRemoved = Gladiators.FirstOrDefault(x => x.Name == name);
            Gladiators.Remove(toBeRemoved);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator highesStatPower = Gladiators.OrderByDescending(x => x.GetStatPower()).FirstOrDefault();
            return highesStatPower;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator toReturn = Gladiators.OrderByDescending(x => x.GetWeaponPower()).FirstOrDefault();
            return toReturn;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladiatorTpReturn = Gladiators.OrderByDescending(x => x.GetTotalPower()).FirstOrDefault();
            return gladiatorTpReturn;
        }

        public override string ToString()
        {
            return $"{Name} - {Count} gladiators are participating."; 
        }

    }

}
