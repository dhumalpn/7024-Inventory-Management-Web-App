using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<InventoryManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryManagementContext") ?? throw new InvalidOperationException("Connection string 'InventoryManagementContext' not found.")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
