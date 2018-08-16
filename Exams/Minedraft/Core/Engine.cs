using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Shutdown")
        {
            List<string> inputCommandOfArgs = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = inputCommandOfArgs[0];
            List<string> commandOfArgs = inputCommandOfArgs.Skip(1).ToList();
            CompliteCommand(command, commandOfArgs);
        }
        Console.WriteLine(draftManager.ShutDown()); 
    }

    private void CompliteCommand(string command, List<string> commandOfArgs)
    {
        switch (command)
        {
            case "RegisterHarvester":
                Console.WriteLine(draftManager.RegisterHarvester(commandOfArgs));
                break;
            case "RegisterProvider":
                Console.WriteLine(draftManager.RegisterProvider(commandOfArgs)); 
                break;
            case "Day":
                Console.WriteLine(draftManager.Day()); 
                break;
            case "Mode":
                Console.WriteLine(draftManager.Mode(commandOfArgs)); 
                break;
            case "Check":
                Console.WriteLine(draftManager.Check(commandOfArgs)); 
                break;
        }
    }
}

