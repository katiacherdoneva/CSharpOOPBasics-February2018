public class Robot : SocietyMember, IRobot
{
    public Robot(string model, string id) : base(id)
    {
        Model = model;
    }

    public string Model { get; set; }
}

