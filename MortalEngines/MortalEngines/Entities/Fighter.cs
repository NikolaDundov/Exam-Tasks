namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine
    {
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints += 50, defensePoints -= 25, 200)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
                this.AggressiveMode = false;
            }

            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
                this.AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            if (AggressiveMode)
            {
                string toAdd = " *Aggressive: ON";
                return base.ToString() + toAdd.ToString().TrimEnd();

            }
            else
            {
                string toAdd = " *Aggressive: OFF";
                return base.ToString() + toAdd.ToString().TrimEnd();
            }
        }
    }
}
