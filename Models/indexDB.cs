using Magic.IndexedDb;
using Magic.IndexedDb.Interfaces;
using Magic.IndexedDb.SchemaAnnotations;
using System;

public class IndexedDbContext : IMagicRepository
{
    public static readonly IndexedDbSet Client = new("Client");
    public static readonly IndexedDbSet Employee = new("Employee");
    public static readonly IndexedDbSet Animal = new("Animal");
    public static readonly IndexedDbSet CashFlow = new("CashFlow");

    // acc
    public static readonly IndexedDbSet Account = new("Account");
    public static readonly IndexedDbSet JournalEntries = new("JournalEntries");
    public static readonly IndexedDbSet JournalLines = new("JournalLines");
    public static readonly IndexedDbSet Invoices = new("Invoices");
    public static readonly IndexedDbSet Bills = new("Bills");
    public static readonly IndexedDbSet Payments = new("Payments");
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


public class CashFlow : MagicTableTool<CashFlow>, IMagicTable<IndexedDbContext>
{
    // // Databases property returning the IndexedDbContext instance
    public IndexedDbContext Databases { get; } = new IndexedDbContext();

    public IMagicCompoundKey GetKeys() =>
        CreatePrimaryKey(x => x.Id, true);

    public string GetTableName() => "CashFlow";

    public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.CashFlow;

    // Implement compound indexes if you have any, else null
    public List<IMagicCompoundIndex> GetCompoundIndexes()
    {
        // Return an empty list if you don't have any compound indexes
        return new List<IMagicCompoundIndex>();
    }

    // Your model properties
    public int Id { get; set; }
    [MagicIndex]

    // For dates, use DateTime type (not string)
    public DateTime TransactionDate { get; set; } = DateTime.Now;

    // Description as string (no length constraints here, usually enforced in DB)
    public string? Description { get; set; }

    // Decimal types for money amounts
    public decimal CashInflow { get; set; } = 0;

    public decimal CashOutflow { get; set; } = 0;

    // Computed property (not mapped to DB by default, but you can calculate)
    public decimal NetCashFlow => CashInflow - CashOutflow;

    // EndingBalance is usually calculated elsewhere, but if stored:
    public decimal EndingBalance { get; set; }


}
