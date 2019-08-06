using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, 450)
        {
            
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 70 || value > 100)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }

        }
    }
}
