using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, 
            double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }


        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double points = Math.Abs(this.AttackPoints - target.DefensePoints);
            target.HealthPoints -= points;
            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");
            sb.AppendLine(" * Targets: ");

            if (this.Targets.Count > 0)
            {
                sb.AppendLine(string.Join(",", Targets));
            }

            else
            {
                sb.AppendLine("None");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
