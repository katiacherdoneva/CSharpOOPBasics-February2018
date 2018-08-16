public class SocietyMember : IIdentifiable
{
    public SocietyMember(string id)
    {
        Id = id;
    }
    public string Id { get; set; }
}

