namespace Minedraft.Harvesters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    abstract class Harvester
    {
        public string Id;
        public double OreOutput;
        public double EnergyRequirement;

        public Harvester(string id, double oreOutput, double energyRequirement)
        {
            this.Id = id;
            this.OreOutput = oreOutput;
            this.EnergyRequirement = energyRequirement;

            if (OreOutput < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreRequirement");
            }
            if (EnergyRequirement < 0 || EnergyRequirement > 20000)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
        }
        public abstract string GetType();
    }
}
