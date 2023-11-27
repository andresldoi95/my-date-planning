using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MyDatePlanningApi.Services.Implementations;
using MyDatePlanningApi.Services.Interfaces;
using MyDatePlanningData;
using MyDatePlanningRepositories.Implementations;
using MyDatePlanningRepositories.Interfaces;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDatePlanningDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatePlanningDb")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IStringHasher, StringHasher>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<MyDatePlanningDBContext>();
    if (dbContext != null)
    {
        dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
