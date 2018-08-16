public class Participant
{
    private string id;

    protected Participant(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
}

