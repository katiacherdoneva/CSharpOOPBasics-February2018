﻿using System;
using System.Text;

public abstract class Provider : Participant
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) 
        : base(id)
    {
        EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if(value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Provider - {Id}");
        sb.AppendLine($"Energy Output: {EnergyOutput}");
        return sb.ToString().TrimEnd();
    }
}

