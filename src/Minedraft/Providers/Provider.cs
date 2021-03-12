namespace Minedraft.Providers
{
    using System;

    abstract class Provider
    {
        public string Id;
        public double EnergyOutput;

        public Provider(string id, double energyOutput)
        {
            this.Id = id;
            this.EnergyOutput = energyOutput;

            if (energyOutput < 0)
            {
                throw new ArgumentException("Energy output should not be negative number.");
            }
            if (energyOutput > 10000)
            {
                throw new ArgumentException("Energy output should not be over 10,000.");
            }
        }
        public abstract string GetType();
    }
}
