using System.Collections.Generic;

public class TyreFactory
{
    public static Tyre CreateTyre(string tyreType, double tyreHardness, List<string> commandArgs)
    {
        Tyre tyre;
        if (tyreType == "Hard")
        {
            return tyre = new HardTyre(tyreHardness);
        }
        double grip = double.Parse(commandArgs[6]);
        return tyre = new UltrasoftTyre(tyreHardness, grip);
    }
}

