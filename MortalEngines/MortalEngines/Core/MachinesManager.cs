namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == name);
            if (pilot != null)
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                pilot = new Pilot(name);
                this.pilots.Add(pilot);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = new Tank(name, attackPoints, defensePoints);

            if (this.machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                this.machines.Add(tank);
                return string.Format(OutputMessages.TankManufactured,
                    name, attackPoints, defensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            else
            {
                var fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);
                return string.Format(OutputMessages.FighterManufactured,
                    name, fighter.AttackPoints, fighter.DefensePoints, fighter.AggressiveMode == true ? "ON" : "OFF");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {


            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);
            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                machine.Pilot = pilot;
                pilot.AddMachine(machine);
                return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attacker = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            var deffending = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);
            if (deffending == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attacker.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            if (deffending.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(deffending);
            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName,
                attackingMachineName, deffending.HealthPoints);

        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);
            return pilot.ToString();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(x => x.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machines.FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == nameof(Fighter)) == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            Fighter fighter = (Fighter)this.machines.FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == nameof(Fighter));
            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighter.Name);

        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machines.FirstOrDefault(m => m.Name == tankName && m.GetType().Name == nameof(Tank)) == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            Tank tank = (Tank)this.machines.FirstOrDefault(m => m.Name == tankName && m.GetType().Name == nameof(Tank));
            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tank.Name);
        }
    }
}