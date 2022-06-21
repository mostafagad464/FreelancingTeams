using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Models;

string s = "";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddDbContext<FreeLanceProjectContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// for scaffolding problem
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


// Dependancy Injection
//builder.Services.AddScoped<ICRUD<Account>, AccountRepository>();
builder.Services.AddScoped<IAccount<Account>, AccountRepository>();
builder.Services.AddScoped<IClient<Client>, ClientRepository>();
builder.Services.AddScoped<IProject<Project>, ProjectRepository>();
builder.Services.AddScoped<ITeam<Team>, TeamRepository>();
builder.Services.AddScoped<ITransaction<Transaction>, TransactionRepository>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opstion =>
{
    opstion.AddPolicy(s,
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
