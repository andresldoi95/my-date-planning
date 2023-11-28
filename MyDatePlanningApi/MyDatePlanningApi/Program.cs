using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyDatePlanningApi.Services.Implementations;
using MyDatePlanningApi.Services.Interfaces;
using MyDatePlanningData;
using MyDatePlanningRepositories.Implementations;
using MyDatePlanningRepositories.Interfaces;
using System.Globalization;
using System.Text;

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
builder.Services.AddScoped<IJwtAuthenticator, JwtAuthenticator>();


var jwtKey = builder.Configuration["jwt_key"];
if (jwtKey != null)
{
    var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["jwt_issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["jwt_audience"],
                ValidateLifetime = true,
                IssuerSigningKey = signInKey,
                ValidateIssuerSigningKey = true
            };
        });
}


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
