public class AccountRepository
{
    public static readonly List<Account> accounts = new List<Account>
    {
        new Account
        {
            Id = 1,
            name = "General Asset",
            code = "A001",
            Type = AccountType.Asset,
            is_active = true
        },
        new Account
        {
            Id = 2,
            name = "General Liability",
            code = "L001",
            Type = AccountType.Liability,
            is_active = true
        },
        new Account
        {
            Id = 3,
            name = "General Equity",
            code = "EQ001",
            Type = AccountType.Equity,
            is_active = true
        },
        new Account
        {
            Id = 4,
            name = "General Revenue",
            code = "R001",
            Type = AccountType.Revenue,
            is_active = true
        },
        new Account
        {
            Id = 5,
            name = "General Expense",
            code = "EX001",
            Type = AccountType.Expense,
            is_active = true
        }
    };

    //Invoice
    public static readonly JournalEntries journalEntry1 = new JournalEntries
    {
        Id = 1,
        Date = DateTime.Now,
        Description = "Invoice",
        CreatedBy = "system",
    };

    public static readonly List<JournalLines> journalLines1 = new List<JournalLines>
    {
        new JournalLines
    {
        Id=1,
        JournalEntryId=1,
        AccountId=1,
        Debit = 10000,
        Credit = null,
        Description ="Piutang Usaha",
    },
        new JournalLines
    {
        Id=2,
        JournalEntryId=1,
        AccountId=4,
        Debit = null,
        Credit = 1000,
        Description ="Penjualan",
    }
    };

    // ## 2. **Bill** (Pembelian dari Vendor)

    // Misal: Terima tagihan pembelian senilai Rp 5.000.000.

    // | Debit                        | Kredit                 | Keterangan                 |
    // | ---------------------------- | ---------------------- | -------------------------- |
    // | Beban / Persediaan 5.000.000 | Hutang Usaha 5.000.000 | Mencatat tagihan pembelian |

    //Bill
    public static readonly JournalEntries journalEntry2 = new JournalEntries
    {
        Id = 2,
        Date = DateTime.Now,
        Description = "Bill",
        CreatedBy = "system",
    };

    public static readonly List<JournalLines> journalLines2 = new List<JournalLines>
    {
        new JournalLines
    {
        Id=3,
        JournalEntryId=2,
        AccountId=5,
        AccountType = AccountType.Expense,
        Debit = 10000,
        Credit = null,
        Description ="Beban / Persediaan",
    },
        new JournalLines
    {
        Id=4,
        JournalEntryId=2,
        AccountId=2,
        AccountType = AccountType.Liability,
        Debit = null,
        Credit = 1000,
        Description ="Hutang Usaha",
    }
    };


    // ## 3. **Payment** (Pembayaran)

    // ### a. Pembayaran dari Customer untuk Invoice Rp 10.000.000

    // | Debit                 | Kredit                   | Keterangan                        |
    // | --------------------- | ------------------------ | --------------------------------- |
    // | Kas / Bank 10.000.000 | Piutang Usaha 10.000.000 | Menerima pembayaran dari customer |

    //Payment Invoice
    public static readonly JournalEntries journalEntry3 = new JournalEntries
    {
        Id = 3,
        Date = DateTime.Now,
        Description = "Payment Invoice",
        CreatedBy = "system",
    };

    public static readonly List<JournalLines> journalLines3 = new List<JournalLines>
    {
        new JournalLines
    {
        Id=5,
        JournalEntryId=3,
        AccountId=1,
        Debit = 10000,
        Credit = null,
        Description ="Kas / Bank",
    },
        new JournalLines
    {
        Id=6,
        JournalEntryId=3,
        AccountId=1,
        Debit = null,
        Credit = 1000,
        Description ="Piutang Usaha",
    }
    };

    // ### b. Pembayaran ke Vendor untuk Bill Rp 5.000.000

    // | Debit                  | Kredit               | Keterangan                 |
    // | ---------------------- | -------------------- | -------------------------- |
    // | Hutang Usaha 5.000.000 | Kas / Bank 5.000.000 | Membayar tagihan ke vendor |

    //Payment Bill
    public static readonly JournalEntries journalEntry4 = new JournalEntries
    {
        Id = 4,
        Date = DateTime.Now,
        Description = "Invoice",
        CreatedBy = "system",
    };

    public static readonly List<JournalLines> journalLines4 = new List<JournalLines>
    {
        new JournalLines
    {
        Id=7,
        JournalEntryId=4,
        AccountId=2,
        Debit = 10000,
        Credit = null,
        Description ="Hutang Usaha",
    },
        new JournalLines
    {
        Id=8,
        JournalEntryId=4,
        AccountId=1,
        Debit = null,
        Credit = 1000,
        Description ="Kas / Bank",
    }
    };


}
