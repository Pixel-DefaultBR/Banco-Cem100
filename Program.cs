using BancoCem.Database;
using BancoCem.Database.Repository.Transferences;
using BancoCem.Database.Repository.Wallets;
using BancoCem.Services.Authorizator;
using BancoCem.Services.Notification;
using BancoCem.Services.Transference;
using BancoCem.Services.Wallets;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("defaultConnection"), serverVersion));

builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<ITransferenceRepository, TransferenceRepository>();

builder.Services.AddScoped<IWalletServices, WalletServices>();
builder.Services.AddHttpClient<IAuthorizatorServices, AuthorizatorServices>(client =>
{
    client.BaseAddress = new Uri("https://util.devi.tools/api/v2/");
});

builder.Services.AddScoped<IAuthorizatorServices, AuthorizatorServices>();
builder.Services.AddScoped<INotificationServices, NotificationServices>();
builder.Services.AddScoped<ITransferenceServices, TransferenceServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
