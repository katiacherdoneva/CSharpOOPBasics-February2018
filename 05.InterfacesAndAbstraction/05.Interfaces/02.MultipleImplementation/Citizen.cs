public class Citizen : IIdentifiable, IBirthable
{
    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Citizen(string name, int age, string id, string birthday)
        : this(name, age)
    {
        this.ID = id;
        this.Birthdate = birthday;
    }
    public string Name { get; set; }

    public int Age { get; set; }

    public string ID { get; set; }

    public string Birthdate { get; set; }
}