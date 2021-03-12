namespace Minedraft.Providers
{
    class PressureProvider : Provider
    {
        public PressureProvider(string id, double energyOutput) : base(id, energyOutput * 1.5)
        {

        }
        public override string GetType()
        {
            return "Pressure";
        }
    }
}
