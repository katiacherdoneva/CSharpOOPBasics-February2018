using System;
using System.Text;

public class Song
{
    private string artist;
    private string name;
    private int length;
    private int minutes;
    private int seconds;

    public Song(string artist, string name, int minutes, int seconds)
    {
        Artist = artist;
        Name = name;
        Minutes = minutes;
        Seconds = seconds;
    }

    public string Artist
    {
        get { return artist; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            artist = value;
        }
    }


    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            name = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            seconds = value;
        }
    }

    public int CalculateLengthSong()
    {
        int timeInSecond = (minutes * 60) + seconds;
        return timeInSecond;
    }
}

