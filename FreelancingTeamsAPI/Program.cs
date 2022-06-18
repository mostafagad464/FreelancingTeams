using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Models;
using System.Text.Json.Serialization;

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
builder.Services.AddScoped<ITransaction<Transaction, ProjectPayment>, TransactionRepository>();
builder.Services.AddScoped<ITeamTransactions<TeamTransaction>, TeamTransactionRepository>();




builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
