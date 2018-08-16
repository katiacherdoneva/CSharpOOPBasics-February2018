using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider CreateProvider(List<string> commandOfArgs)
    {
        string type = commandOfArgs[0];
        string id = commandOfArgs[1];
        double energyOutput = double.Parse(commandOfArgs[2]);

        Provider provider = null;
        if (type == "Pressure")
        {
            provider = new PressureProvider(id, energyOutput);
        }
        else
        {
            provider = new SolarProvider(id, energyOutput);
        }
        return provider;
    }
}

