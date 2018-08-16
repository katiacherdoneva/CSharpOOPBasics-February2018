public interface IBuyer
{
    string Name { get; }
    int Age { get; }
    int Food { get; }

    int BuyFood();
}

