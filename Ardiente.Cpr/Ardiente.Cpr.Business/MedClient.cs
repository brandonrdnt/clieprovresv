namespace Ardiente.Cpr.Business;

public class MedClient
{
    public MedClient(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
}