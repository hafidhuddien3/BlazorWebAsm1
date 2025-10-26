using Magic.IndexedDb;
using Magic.IndexedDb.Interfaces;
using Magic.IndexedDb.SchemaAnnotations;

public class Account : MagicTableTool<Account>, IMagicTable<IndexedDbContext>
{
    // // Databases property returning the IndexedDbContext instance
    public IndexedDbContext Databases { get; } = new IndexedDbContext();

    public IMagicCompoundKey GetKeys() =>
        CreatePrimaryKey(x => x.Id, true);

    public string GetTableName() => "Account";

    public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.Account;

    // Implement compound indexes if you have any, else null
    public List<IMagicCompoundIndex> GetCompoundIndexes()
    {
        // Return an empty list if you don't have any compound indexes
        return new List<IMagicCompoundIndex>();
    }

    // Your model properties
    public int Id { get; set; }
    [MagicIndex]
    public string? name { get; set; }
    public string? code { get; set; }
    public AccountType Type { get; set; }
    public Boolean is_active { get; set; } = true;

}


public enum AccountType
{
    Asset,
    Liability,
    Equity,
    Revenue,
    Expense
}

public class JournalEntries : MagicTableTool<JournalEntries>, IMagicTable<IndexedDbContext>
{
    // // Databases property returning the IndexedDbContext instance
    public IndexedDbContext Databases { get; } = new IndexedDbContext();

    public IMagicCompoundKey GetKeys() =>
        CreatePrimaryKey(x => x.Id, true);

    public string GetTableName() => "JournalEntries";

    public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.JournalEntries;

    // Implement compound indexes if you have any, else null
    public List<IMagicCompoundIndex> GetCompoundIndexes()
    {
        // Return an empty list if you don't have any compound indexes
        return new List<IMagicCompoundIndex>();
    }

    // Your model properties
    public int Id { get; set; }
    [MagicIndex]
    public DateTime? Date { get; set; } = DateTime.Now;
    public string? Description { get; set; }
    public string? CreatedBy { get; set; }

}

public class JournalLines : MagicTableTool<JournalLines>, IMagicTable<IndexedDbContext>
{
    // // Databases property returning the IndexedDbContext instance
    public IndexedDbContext Databases { get; } = new IndexedDbContext();

    public IMagicCompoundKey GetKeys() =>
        CreatePrimaryKey(x => x.Id, true);

    public string GetTableName() => "JournalLines";

    public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.JournalLines;

    // Implement compound indexes if you have any, else null
    public List<IMagicCompoundIndex> GetCompoundIndexes()
    {
        // Return an empty list if you don't have any compound indexes
        return new List<IMagicCompoundIndex>();
    }

    // Your model properties
    public int Id { get; set; }
    [MagicIndex]
    public int? JournalEntryId { get; set; }
    public int? AccountId { get; set; }
    public AccountType? AccountType { get; set; }
    public decimal? Debit { get; set; }
    public decimal? Credit { get; set; }
    public string? Description { get; set; }
    public string? JournalDescription { get; set; }
    public DateTime? Date { get; set; } = DateTime.Now;

}

public class Invoices : MagicTableTool<Invoices>, IMagicTable<IndexedDbContext>
{
    // // Databases property returning the IndexedDbContext instance
    public IndexedDbContext Databases { get; } = new IndexedDbContext();

    public IMagicCompoundKey GetKeys() =>
        CreatePrimaryKey(x => x.Id, true);

    public string GetTableName() => "Invoices";

    public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.Invoices;

    // Implement compound indexes if you have any, else null
    public List<IMagicCompoundIndex> GetCompoundIndexes()
    {
        // Return an empty list if you don't have any compound indexes
        return new List<IMagicCompoundIndex>();
    }

    // Your model properties
    public int Id { get; set; }
    [MagicIndex]

    public string? CustomerId { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal? TotalAmount { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}



public class Bills : MagicTableTool<Bills>, IMagicTable<IndexedDbContext>
{
    // // Databases property returning the IndexedDbContext instance
    public IndexedDbContext Databases { get; } = new IndexedDbContext();

    public IMagicCompoundKey GetKeys() =>
        CreatePrimaryKey(x => x.Id, true);

    public string GetTableName() => "Bills";

    public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.Bills;

    // Implement compound indexes if you have any, else null
    public List<IMagicCompoundIndex> GetCompoundIndexes()
    {
        // Return an empty list if you don't have any compound indexes
        return new List<IMagicCompoundIndex>();
    }

    // Your model properties
    public int Id { get; set; }
    [MagicIndex]

    public string? VendorId { get; set; }
    public DateTime? BillDate { get; set; }//Tanggal tagihan diterima
    public DateTime? DueDate { get; set; }//Tanggal jatuh tempo pembayaran
    public decimal? TotalAmount { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}


public class Payments : MagicTableTool<Payments>, IMagicTable<IndexedDbContext>
{
    // // Databases property returning the IndexedDbContext instance
    public IndexedDbContext Databases { get; } = new IndexedDbContext();

    public IMagicCompoundKey GetKeys() =>
        CreatePrimaryKey(x => x.Id, true);

    public string GetTableName() => "Payments";

    public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.Payments;

    // Implement compound indexes if you have any, else null
    public List<IMagicCompoundIndex> GetCompoundIndexes()
    {
        // Return an empty list if you don't have any compound indexes
        return new List<IMagicCompoundIndex>();
    }

    // Your model properties
    public int Id { get; set; }
    [MagicIndex]

    public DateTime? PaymentDate { get; set; }     // Tanggal pembayaran dilakukan                      
    public decimal? Amount { get; set; }  // Jumlah uang yang dibayarkan                       
    public string? PaymentMethod { get; set; }  // Metode pembayaran (Cash, Bank, Transfer)          
    public string? InvoiceId { get; set; } // Relasi ke invoice (jika pembayaran dari customer) |
    public string? BillId { get; set; } // Relasi ke bill (jika pembayaran ke vendor)
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}
