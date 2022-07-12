using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Models;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using FreelancingTeamsAPI.Hubs;

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

builder.Services.AddScoped<IDeal<Deal>, DealRepository>();
builder.Services.AddScoped<IProposal<Proposal>, ProposalRepository>();
builder.Services.AddScoped<IAccount<Account>, AccountRepository>();
builder.Services.AddScoped<IUser<User>, UserRepository>();
builder.Services.AddScoped<IProject<Project>, ProjectRepository>();
builder.Services.AddScoped<ITeam<Team>, TeamRepository>();
builder.Services.AddScoped<IPortoflio<Portoflio>, PortoflioRepository>();
builder.Services.AddScoped<IWallet<Wallet>, WalletRepository>();
builder.Services.AddScoped<IComplain<Complain>, ComplainRepository>();
builder.Services.AddScoped<IExperience<FreelancerExperience>, FreelancerExperienceRepository>();
builder.Services.AddScoped<IEducationSkill<FreelancerEducation>, FreelancerEducationRepository>();
builder.Services.AddScoped<IEducationSkill<FreelancerSkill>, FreelancerSkillRepository>();
builder.Services.AddScoped<ICertificate<FreelancerCertificate>, FreelancerCertificateRepository>();
builder.Services.AddScoped<ICategory<Category>, CategoryRepository>();
builder.Services.AddScoped<ISkill<Skill>, SkillRepository>();
builder.Services.AddScoped<IUserCredit<UserCredit>, UserCreditRepository>();
builder.Services.AddScoped<IUserLanguage<UserLanguage>, UserLanguageRepository>();
builder.Services.AddScoped<IUserSocial<UserSocial>, UserSocialRepository>();
builder.Services.AddScoped<ITransaction<Transaction, ProjectPayment>, TransactionRepository>();
builder.Services.AddScoped<ITeamTransactions<TeamTransaction>, TeamTransactionRepository>();
builder.Services.AddScoped<IReview<Review>, ReviewRepository>();
builder.Services.AddScoped<IMessages<AccountMessage>, AccountMessagesRepository>();
builder.Services.AddScoped<IMessages<TeamFreelancerMessage>, FreelancerTeamsMessagesRepository>();
builder.Services.AddScoped<IUserConnection<UserConnection>, UserConnectionRepository>();





builder.Services.AddControllers();

builder.Services.AddSignalR();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
            builder.AllowCredentials().WithOrigins("http://localhost:4200");
        }) ;
});

//JWT 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to my key"))

    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(s);

app.UseHttpsRedirection();

app.MapHub<ChatHub>("/chat");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
