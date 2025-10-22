using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazor1;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

//
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "AccountingDB";
    dbStore.Version = 1;

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "JournalEntries",
        PrimaryKey = new IndexSpec { Name = "Id", KeyPath = "Id", Auto = false },
        Indexes = new[]
        {
            new IndexSpec { Name = "Date", KeyPath = "Date", Auto = false },
            new IndexSpec { Name = "Description", KeyPath = "Description", Auto = false }
        }
    });

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "JournalLines",
        PrimaryKey = new IndexSpec { Name = "Id", KeyPath = "Id", Auto = false },
        Indexes = new[]
        {
            new IndexSpec { Name = "JournalId", KeyPath = "JournalId", Auto = false },
            new IndexSpec { Name = "AccountId", KeyPath = "AccountId", Auto = false },
            new IndexSpec { Name = "Debit", KeyPath = "Debit", Auto = false },
            new IndexSpec { Name = "Credit", KeyPath = "Credit", Auto = false }
        }
    });

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "Accounts",
        PrimaryKey = new IndexSpec { Name = "Id", KeyPath = "Id", Auto = false },
        Indexes = new[]
        {
            new IndexSpec { Name = "Name", KeyPath = "Name", Auto = false },
            new IndexSpec { Name = "Type", KeyPath = "Type", Auto = false }
        }
    });
});
