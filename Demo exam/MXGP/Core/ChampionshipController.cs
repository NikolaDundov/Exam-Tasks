using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {

        private readonly RiderRepository riderRepository;
        private readonly RaceRepository raceRepository;
        private readonly MotorcycleRepository motorcycleRepository;

        public ChampionshipController()
        {
            this.riderRepository = new RiderRepository();
            this.raceRepository = new RaceRepository();
            this.motorcycleRepository = new MotorcycleRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            var motorcycle = motorcycleRepository.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepository.GetByName(raceName);
            var rider = this.riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {

            if (this.motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            Motorcycle motorcycle = null;
            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            else if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(motorcycle);
            return $"{motorcycle.GetType().Name} {model} is created."; 
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            var race = new Race(name, laps);
            this.raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {

            if (riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            var rider = new Rider(riderName);
            riderRepository.Add(rider);
            return $"Rider {riderName} is created.";

        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }


            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var finalist = race.Riders.OrderByDescending
                (x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rider {finalist[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {finalist[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {finalist[2].Name} is third in {raceName} race.");

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
