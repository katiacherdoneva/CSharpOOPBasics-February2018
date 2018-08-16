using System;

public class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public Box(decimal length, decimal width, decimal height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public decimal Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Length cannot be zero or negative.");
            length = value;
        }
    }

    public decimal Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Width cannot be zero or negative.");
            width = value;
        }
    }

    public decimal Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Height cannot be zero or negative.");
            height = value;
        }
    }

    public decimal GetVolume()
    {
        return this.length * this.width * this.height;
    }

    public decimal GetLateralSurfaceArea()
    {
        return 2 * this.length * this.height + 2 * this.width * this.height;
    }
    public decimal GetSurfaceArea()
    {
        return 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
    }

    public override string ToString()
    {
        return $"Surface Area - {GetSurfaceArea():f2}" +
            $"\r\nLateral Surface Area - {GetLateralSurfaceArea():f2}" +
            $"\r\nVolume - {GetVolume():f2}";
    }
}