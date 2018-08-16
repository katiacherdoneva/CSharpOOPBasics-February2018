using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    RaceTower raceTower;
    public bool isEnd;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        int totalLaps = int.Parse(Console.ReadLine());
        int lengthOfTheTrack = int.Parse(Console.ReadLine());
        raceTower.SetTrackInfo(totalLaps, lengthOfTheTrack);

        while(raceTower.IsEndOfRace != true)
        {
            List<string> inputCommandOfArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = inputCommandOfArg[0];
            List<string> commandOfArg = inputCommandOfArg.Skip(1).ToList();
            CompliteCommand(totalLaps, lengthOfTheTrack, command, commandOfArg);
        }

        if (this.raceTower.IsEndOfRace)
        {
            Console.WriteLine(
                $"{this.raceTower.Winner.Name} wins the race for {this.raceTower.Winner.TotalTime:F3} seconds.");
            Environment.Exit(0);
        }
    }

    private void CompliteCommand(int totalLaps, int lengthOfTheTrack, string command, List<string> commandOfArg)
    {
        switch(command)
        {
            case "RegisterDriver":
                raceTower.RegisterDriver(commandOfArg);
                break;
            case "Leaderboard":
                Console.WriteLine(this.raceTower.GetLeaderboard()); 
                break;
            case "CompleteLaps":
                StringBuilder result = new StringBuilder();
                   result.AppendLine(this.raceTower.CompleteLaps(commandOfArg));
                if (result.ToString().TrimEnd() != string.Empty)
                {
                    Console.WriteLine(result.ToString().TrimEnd());
                }
                break;
            case "Box":
                raceTower.DriverBoxes(commandOfArg);
                break;
            case "ChangeWeather":
                raceTower.ChangeWeather(commandOfArg);
                break;
        }
    }
}

