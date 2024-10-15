using DbFirstVsCodeFirst.DbFirst.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region DbFirst
builder.Services.AddDbContext<DbFirstVsCodeFirst.DbFirst.Domain.DataContext.MusicDbContext>(options =>
{
    var connStr = builder.Configuration.GetConnectionString("musicDbConString");
    options.UseSqlServer(connStr);
});

builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
#endregion

#region CodeFirst
builder.Services.AddDbContext<DbFirstVsCodeFirst.CodeFirst.Domain.DataContext.MusicDbContext>(options =>
{
    var connStr = builder.Configuration.GetConnectionString("musicDbConString");
    options.UseSqlServer(connStr, b => 
        b.MigrationsAssembly("DbFirstVsCodeFirst"));
});

builder.Services.AddScoped<DbFirstVsCodeFirst.CodeFirst.Domain.Repositories.IArtistRepository, DbFirstVsCodeFirst.CodeFirst.Domain.Repositories.ArtistRepository>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
