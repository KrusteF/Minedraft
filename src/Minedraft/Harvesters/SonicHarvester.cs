namespace Minedraft.Harvesters
{

    class SonicHarvester : Harvester
    {
        public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement / sonicFactor)
        {

        }
        public override string GetType()
        {
            return "Sonic";
        }
    }
}
