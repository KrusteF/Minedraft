namespace Minedraft.Providers
{

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
