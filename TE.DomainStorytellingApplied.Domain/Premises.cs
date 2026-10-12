namespace TE.DomainStorytellingApplied.Domain;

public class Premises
{
    public Id PremisesId { get; }
    public string Name { get; }
    public string Address { get; }
    public int Capacity { get; }
    public IReadOnlyList<string> Equipment { get; }

    public Premises(
        Id premisesId,
        string name,
        string address,
        int capacity,
        IEnumerable<string> equipment)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Premises must have a name", nameof(name));

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Premises must have an address", nameof(address));

        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero");

        PremisesId = premisesId;
        Name = name;
        Address = address;
        Capacity = capacity;
        Equipment = equipment.ToArray();
    }
}