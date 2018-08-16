public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += (oreOutput * 200) / 100;
        this.EnergyRequirement *= 2;
    }

    public override string ToString()
    {
        return "Hammer " + base.ToString();
    }
}

