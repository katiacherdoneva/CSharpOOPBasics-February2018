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

    private decimal Length
    {
        get { return length; }
        set { length = value; }
    }

    private decimal Width
    {
        get { return width; }
        set { width = value; }
    }

    private decimal Height
    {
        get { return height; }
        set { height = value; }
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

