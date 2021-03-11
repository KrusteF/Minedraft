using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Harvesters
{
    class HammerHarvester : Harvester
    {
        public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput * 3, energyRequirement * 2)
        {
            
        }
        public override string GetType()
        {
            return "Hammer";
        }
    }
}
