public sealed record Id 
{
    public string Value { get; private set; }

    private Id(string value) 
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new Exception("");

            Value = value; 
    }

    public static Id Generate() => new(Guid.NewGuid().ToString());
}