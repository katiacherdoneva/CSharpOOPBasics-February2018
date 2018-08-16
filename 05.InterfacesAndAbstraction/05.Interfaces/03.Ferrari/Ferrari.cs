using System.Text;

public class Ferrari : IFerrari
{
    public Ferrari(string driver)
    {
        Driver = driver;
    }

    public string Model => "488-Spider";

    public string Driver { get; set; }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string UseGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{Model}/{UseBrakes()}/{UseGasPedal()}/{Driver}";
    }
}

