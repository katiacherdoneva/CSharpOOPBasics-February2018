using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        Harvester harvester = null;
        if (type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
        else
        {
            harvester = new HammerHarvester(id, oreOutput, energyRequirement);
        }
        return harvester;
    }
}

