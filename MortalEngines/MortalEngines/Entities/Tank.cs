using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine
    {
        public Tank(string name, double attackPoints, double defensePoints) :
            base(name, attackPoints -= 40, defensePoints += 30, 100)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            if (DefenseMode)
            {
                return base.ToString() + " *Defense: ON".ToString().TrimEnd();
            }
            else
            {
                return base.ToString() + " *Defense: OFF".ToString().TrimEnd();
            }
        }
    }
}
