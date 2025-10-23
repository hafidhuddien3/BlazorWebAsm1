using Magic.IndexedDb;
using Magic.IndexedDb.Interfaces;
using Magic.IndexedDb.SchemaAnnotations;
using System;

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

public class IndexedDbContext : IMagicRepository
{
    public static readonly IndexedDbSet Client = new("Client");
    public static readonly IndexedDbSet Employee = new("Employee");
    public static readonly IndexedDbSet Animal = new("Animal");
}



public class Client : MagicTableTool<Client>, IMagicTable<IndexedDbContext>
{
    // Databases property returning the IndexedDbContext instance
    public IndexedDbContext Databases { get; } = new IndexedDbContext();

    public IMagicCompoundKey GetKeys() =>
        CreatePrimaryKey(x => x.Id, true);

    public string GetTableName() => "Client";

    public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.Client;

    // Implement compound indexes if you have any, else null
    public List<IMagicCompoundIndex> GetCompoundIndexes()
    {
        // Return an empty list if you don't have any compound indexes
        return new List<IMagicCompoundIndex>();
    }

    // Your model properties
    public int Id { get; set; }

    [MagicIndex]
    public string Name { get; set; }

    public int Age { get; set; }

}
