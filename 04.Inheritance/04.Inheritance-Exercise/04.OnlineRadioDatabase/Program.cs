using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<Song> playlist = GetPlaylist();
        PrintPlaylist(playlist);
    }

    private static void PrintPlaylist(List<Song> playlist)
    {
        List<int> allTime = GetLength(playlist); //hh\:mm\:ss
        Console.WriteLine($"Songs added: {playlist.Count}" +
            $"\r\nPlaylist length: {allTime[2]}h {allTime[1]}m {allTime[0]}s");
    }

    private static List<int> GetLength(List<Song> playlist)
    {
        int totalDuration = playlist.Sum(x => x.CalculateLengthSong());
        int hours = totalDuration / 3600;
        totalDuration -= hours * 3600;
        int minutes = totalDuration / 60;
        totalDuration -= minutes * 60;
        int seconds = totalDuration;

        List<int> time = new List<int>();
        time.Add(seconds);
        time.Add(minutes);
        time.Add(hours);

        return time;
    }

    private static List<Song> GetPlaylist()
    {
        var numberOfSongs = int.Parse(Console.ReadLine());
        var playlist = new List<Song>();
        for (int i = 0; i < numberOfSongs; i++)
        {
            try
            {
                var songInfo = Console.ReadLine()
                               .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var artistName = songInfo[0];
                var songName = songInfo[1];
                List<int> songDuration;

                try
                {
                    songDuration = songInfo[2]
                                   .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();
                }
                catch
                {
                    throw new ArgumentException("Invalid song length.");
                }

                Song song = new Song(artistName, songName, songDuration[0], songDuration[1]);
                playlist.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
        return playlist;
    }
}

