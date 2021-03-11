namespace Minedraft.Harvesters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
