using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Weapon = weapon;
            this.Stat = stat;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            return Stat.Agility + Stat.Flexibility + Stat.Skills + Stat.Strength + Stat.Intelligence
                + Weapon.Size + Weapon.Solidity + Weapon.Sharpness;
        }

        public int GetWeaponPower()
        {
            return Weapon.Size + Weapon.Solidity + Weapon.Sharpness;
        }

        public int GetStatPower()
        {
            return Stat.Agility + Stat.Flexibility + Stat.Skills + Stat.Strength + Stat.Intelligence;
        }


        public override string ToString()
        {
            return $"{Name} - {GetTotalPower()}"
                + Environment.NewLine + $"Weapon power: {GetWeaponPower()}"
                + Environment.NewLine + $"Stat power: {GetStatPower()}";
        }

  

    }
}
