namespace TE.DomainStorytellingApplied.Domain;

public class Booker
{
    public Id BookerId { get; }
    public string Name { get; }

    public Booker(Id bookerId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Booker must have a name", nameof(name));

        BookerId = bookerId;
        Name = name;
    }
}