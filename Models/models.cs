public class JournalEntry
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}

public class JournalLine
{
    public string Id { get; set; }
    public string JournalId { get; set; }
    public string AccountId { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
}

public class Account
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // asset, liability, etc.
}
