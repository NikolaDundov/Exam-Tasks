using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(Motorcycle), "Motorcycle cannot be null.");
            }
            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
