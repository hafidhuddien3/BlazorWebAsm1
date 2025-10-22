public class JournalEntry
{
    public required string Id { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
}

public class JournalLine
{
    public required string Id { get; set; }
    public required string JournalId { get; set; }
    public required string AccountId { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
}

public class Account
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Type { get; set; } // asset, liability, etc.
}
