using System;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput += (energyOutput * 50) / 100;
    }

    public override string ToString()
    {
        return "Pressure " + base.ToString();
    }
}
