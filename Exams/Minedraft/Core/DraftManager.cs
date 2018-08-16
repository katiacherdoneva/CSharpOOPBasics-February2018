using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        harvesters = new Dictionary<string, Harvester>();
        providers = new Dictionary<string, Provider>();
        mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        string msg = string.Empty;
        try
        {          
            
            harvesters.Add(id, HarvesterFactory.CreateHarvester(arguments));
            msg = $"Successfully registered {type} Harvester - {id}";
        }
        catch (ArgumentException argEx)
        {
            msg = argEx.Message;
        }
        return msg;
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        string msg = string.Empty;
        try
        {          
            providers.Add(id, ProviderFactory.CreateProvider(arguments));
            msg = $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException argEx)
        {
            msg = argEx.Message;         
        }

        return msg;
    }

    public string Day()
    {
        double dayEnergy = 0;
        double dayOre = 0;
        double harvestNeededEnergyForDay = 0;

        dayEnergy = providers.Sum(v => v.Value.EnergyOutput);
        totalStoredEnergy += dayEnergy;

        harvestNeededEnergyForDay += harvesters.Sum(h => h.Value.EnergyRequirement);

        if (totalStoredEnergy >= harvestNeededEnergyForDay)
        {
            if (mode == "Full")
            {
                dayOre += harvesters.Values.Sum(h => h.OreOutput);
                totalStoredEnergy -= harvestNeededEnergyForDay;
            }
            else if (mode == "Half")
            {
                dayOre += harvesters.Values.Sum(h => (h.OreOutput * 50) / 100);
                totalStoredEnergy -= (harvestNeededEnergyForDay * 60) / 100;
            }

            totalMinedOre += dayOre;
        }
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {dayEnergy}")
            .AppendLine($"Plumbus Ore Mined: {dayOre}");
        return sb.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        mode = arguments[0];
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        if(harvesters.ContainsKey(id))
        {
            return harvesters[id].ToString();
        }
        else if (providers.ContainsKey(id))
        {
            return providers[id].ToString();
        }
        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");
        return sb.ToString().TrimEnd();
    }
}
