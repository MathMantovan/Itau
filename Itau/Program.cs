using Itau.Model;
using Itau.Model.Entities;
using Itau.Service;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ITransactionStore, InMemoryTransactionStore>();
builder.Services.AddScoped<ITransactionsServices, TransactionsService>();

var app = builder.Build();

app.MapControllers();


app.Run();
