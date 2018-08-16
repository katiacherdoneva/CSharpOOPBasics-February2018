public class Robot : SocietyMember
{
    public Robot(string model, string id) : base(id)
    {
        Model = model;
    }

    public string Model { get; set; }
}

