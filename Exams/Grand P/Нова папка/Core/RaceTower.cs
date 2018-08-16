using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class RaceTower
{
    private Dictionary<string, Driver> drivers;
    private Dictionary<Driver, string> unfinishedDrivers;
    private int numberOfLaps;
    private int lenghtOfTrack;
    private int currentLap;
    private string weather;
    public bool IsEndOfRace;
    public Driver Winner { get; private set; }


    public RaceTower()
    {
        this.drivers = new Dictionary<string, Driver>();
        this.unfinishedDrivers = new Dictionary<Driver, string>();
        IsEndOfRace = false;
        weather = "Sunny";
    }

    public int NumberOfLaps
    {
        get => this.numberOfLaps;
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException($"There is no time! On lap {this.currentLap}.");
            }

            this.numberOfLaps = value;
        }
    }

    public int TotalLaps
    {
        get { return numberOfLaps; }
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException($"There is no time! On lap {this.currentLap}.");
            }
            numberOfLaps = value;
        }
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        try
        {
            this.TotalLaps = lapsNumber;
            this.lenghtOfTrack = trackLength;
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }

    public void RegisterDriver(List<string> commandArgs)
    {

        string type = commandArgs[0];
        string name = commandArgs[1];
        string tyreType = commandArgs[4];

        bool IsValidTypeAndTyreType = IsValid(type, tyreType);

        try
        {
            if (IsValidTypeAndTyreType)
            {
                drivers.Add(name, DriverFactory.CreaterDriver(commandArgs));
            }
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driversName = commandArgs[1];
        drivers[driversName].IncrementTotalTime(20);
        if (reasonToBox == "ChangeTyres")
        {
            string typeTyre = commandArgs[2];
            double tyreHardness = double.Parse(commandArgs[3]);
            Tyre tyre = null;
            if (typeTyre == "Ultrasoft")
            {
                double grip = double.Parse(commandArgs[4]);
                tyre = new UltrasoftTyre(tyreHardness, grip);
            }
            else
            {
                tyre = new HardTyre(tyreHardness);
            }
            drivers[driversName].Car.ChangeTyre(tyre);
        }
        else
        {
            double fuelAmount = double.Parse(commandArgs[2]);
            drivers[driversName].Car.FullFuel(fuelAmount);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int inputCurrentLap = int.Parse(commandArgs[0]);
        try
        {
            this.NumberOfLaps -= inputCurrentLap;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        StringBuilder result = new StringBuilder();
        List<Driver> driversToOvertaken = new List<Driver>();
        for (int i = 0; i < inputCurrentLap; i++)
        {
            SetTotalTimeOfDrivers();
            DoDriverContinueTheRace();
            RemoveIneligibleDriversFromDictionary();

            this.currentLap++;
            driversToOvertaken = this.drivers.Values.OrderByDescending(d => d.TotalTime).ToList();

            for (int j = 0; j < driversToOvertaken.Count - 1; j++)
            {
                var firstDriver = driversToOvertaken[j];
                var secondDriver = driversToOvertaken[j + 1];
                var timeFirstDriver = firstDriver.TotalTime;
                var timeSecondDriver = secondDriver.TotalTime;
                double difference = Math.Abs(timeFirstDriver - timeSecondDriver);
                var intervalToOvertake = 2;

                bool isCrash = CheckForSpecialConditions(firstDriver, ref intervalToOvertake);

                if (difference <= intervalToOvertake)
                {
                    if (isCrash)
                    {
                        this.unfinishedDrivers.Add(firstDriver, "Crashed");
                        foreach (var crashDriver in this.unfinishedDrivers)
                        {
                            if (this.drivers.ContainsKey(crashDriver.Key.Name))
                            {
                                this.drivers.Remove(crashDriver.Key.Name);
                            }
                        }
                        continue;
                    }
                    PrintOvertakenDrivers(result, firstDriver, secondDriver, intervalToOvertake);
                }
            }         
        }

        if (this.numberOfLaps == 0)
        {
            this.IsEndOfRace = true;
            this.Winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
        }
        return result.ToString().TrimEnd();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {currentLap}/{currentLap + numberOfLaps}");

        int position = 0;
        foreach (var driver in drivers.OrderBy(x => x.Value.TotalTime))
        {
            sb.AppendLine($"{++position} {driver.Value.Name} {driver.Value.TotalTime:F3}");
        }

        var crashesToPrint = this.unfinishedDrivers.Reverse();
        foreach (var driver in crashesToPrint)
        {
            sb.AppendLine($"{++position} {driver.Key.Name} {driver.Value}");
        }

        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    public bool IsValid(string type, string tyreType)
    {
        if ((type == "Aggressive" || type == "Endurance") && (tyreType == "Hard" || tyreType == "Ultrasoft"))
        {
            return true;
        }
        return false;
    }

    private void SetTotalTimeOfDrivers()
    {
        foreach (var driver in this.drivers.Values)
        {
            driver.IncrementTotalTime(60 / (this.lenghtOfTrack / driver.Speed));
        }
    }

    private bool CheckForSpecialConditions(Driver firstDriver, ref int intervalToOvertake)
    {
        bool isCrash = false;

        if (firstDriver.GetType().Name == "AggressiveDriver"
            && firstDriver.Car.Tyre.GetType().Name == "UltrasoftTyre")
        {
            intervalToOvertake = 3;
            if (this.weather == "Foggy")
            {
                isCrash = true;
            }
        }

        if (firstDriver.GetType().Name == "EnduranceDriver"
            && firstDriver.Car.Tyre.GetType().Name == "HardTyre")
        {
            intervalToOvertake = 3;
            if (this.weather == "Rainy")
            {
                isCrash = true;
            }
        }

        return isCrash;
    }

    private void RemoveIneligibleDriversFromDictionary()
    {
        foreach (var crashDriver in this.unfinishedDrivers)
        {
            if (this.drivers.ContainsKey(crashDriver.Key.Name))
            {
                this.drivers.Remove(crashDriver.Key.Name);
            }
        }
    }

    private void PrintOvertakenDrivers(StringBuilder result, Driver firstDriver, Driver secondDriver, int intervalToOvertake)
    {
        firstDriver.ReductionTotalTime(intervalToOvertake);
        secondDriver.IncrementTotalTime(intervalToOvertake);
        result.AppendLine(
            $"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.currentLap}.");
    }

    private void DoDriverContinueTheRace()
    {
        foreach (var driver in this.drivers.Values)
        {
            try
            {
                driver.ReduceFuelAmount(this.lenghtOfTrack);
                driver.Car.Tyre.ReduceDegradation();
            }
            catch (Exception e)
            {
                this.unfinishedDrivers.Add(driver, e.Message);
            }
        }
    }
}

