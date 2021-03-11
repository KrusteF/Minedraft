namespace Minedraft.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class SolarProvider : Provider
    {
        public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
        {
            //Does nothing
        }
        public override string GetType()
        {
            return "Solar";
        }
    }
}
