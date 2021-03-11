namespace Minedraft
{
    using Harvesters;
    using Providers;
    using System;
    using System.Collections.Generic;

    public class DraftManager
    {
        private double HalfModeEnergyReq = 60;
        private double HalfModeOreOutput = 50;


        private double totalStoredEnergy;
        private double totalMinedOre;
        private string mode;

        private List<Provider> registeredProviders;
        private List<Harvester> registeredHarvesters;

        public DraftManager()
        {
            this.registeredHarvesters = new List<Harvester>();
            this.registeredProviders = new List<Provider>();
            this.totalStoredEnergy = 0;
            this.totalMinedOre = 0;
            this.mode = "Full";
        }
        public string RegisterHarvester(List<string> arguments)
        {
            Harvester harvester;
            string id = arguments[1];
            double oreOutput = double.Parse(arguments[2]);
            double energyRequirement = double.Parse(arguments[3]);

            try
            {
                switch (arguments[0])
                {
                    case "Sonic":
                        int sonicFactor = int.Parse(arguments[4]);
                        harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                        break;
                    case "Hammer":
                        harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                        break;
                    default:
                        return $"Harvester is not registered, because of it's type.";
                }

            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }
            registeredHarvesters.Add(harvester);
            return $"Successfully registered {arguments[0]} Harvester – {id}";

        }
        public string RegisterProvider(List<string> arguments)
        {

            Provider provider;
            string id = arguments[1];
            double energyOutput = double.Parse(arguments[2]);

            try
            {
                switch (arguments[0])
                {

                    case "Solar":
                        provider = new SolarProvider(id, energyOutput);
                        break;
                    case "Pressure":
                        provider = new PressureProvider(id, energyOutput);
                        break;
                    default:
                        return $"Provider is not registered, because of it's type.";
                }

            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }
            registeredProviders.Add(provider);
            return $"Successfully registered {arguments[0]} Provider – {id}";

        }
        public string Day()
        {
            double energyProvided = 0;
            foreach (var provider in registeredProviders)
            {
                energyProvided += provider.EnergyOutput;
            }
            totalStoredEnergy += energyProvided;

            double energyMultiplier = 1.0;
            double oreMultiplier = 1.0;

            switch (this.mode)
            {
                case "Half":
                    energyMultiplier = HalfModeEnergyReq / 100;
                    oreMultiplier = HalfModeOreOutput / 100;
                    break;
                case "Energy":
                    energyMultiplier = 0;
                    oreMultiplier = 0;
                    break;
            }

            double energyConsumed = 0;
            double oreProduced = 0;
            
            foreach (var harvester in registeredHarvesters)
            {
                energyConsumed += harvester.EnergyRequirement * energyMultiplier;
                oreProduced += harvester.OreOutput * oreMultiplier;
            }
            if (energyConsumed <= totalStoredEnergy)
            {
                totalStoredEnergy -= energyConsumed;
                totalMinedOre += oreProduced;
            }
            else
            {
                oreProduced = 0;
            }
            return "A day has passed.\n" +
                   $"Energy Provided: {energyProvided}\n" +
                   $"Plumbus Ore Mined: {oreProduced}";

        }
        public string Mode(List<string> arguments)
        {
            this.mode = arguments[0];
            return $"Successfully changed working mode to {this.mode} Mode";
        }
        public string Check(List<string> arguments)
        {
            string id = arguments[0];
            Harvester harvester = registeredHarvesters.Find(i => i.Id.Equals(id));
            if (harvester != null)
            {
                return $"{harvester.GetType()} Harverster - {id}\n" +
                    $"Ore Output: {harvester.OreOutput}\n" +
                    $"Energy Requirement: {harvester.EnergyRequirement}";
            }
            Provider provider = registeredProviders.Find(i => i.Id.Equals(id));
            if (provider != null)
            {
                return $"{provider.GetType()} Provider - {id}\n" +
                    $"Energy Output: {provider.EnergyOutput}";
            }
            return $"No element found with id - {id}";
        }
        public string Shutdown()
        {
            return "System Shutdown\n" +
                $"Total Energy Stored: {totalStoredEnergy}\n" +
                $"Total Mined Plumbus Ore: {totalMinedOre}";
        }
    }
}
