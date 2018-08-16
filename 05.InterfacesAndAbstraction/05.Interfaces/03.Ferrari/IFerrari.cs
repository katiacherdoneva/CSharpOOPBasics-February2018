public interface IFerrari
{
    string Model { get; }
    string Driver { get; }

    string UseBrakes();
    string UseGasPedal();
}

