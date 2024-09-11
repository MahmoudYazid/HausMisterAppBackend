using businessLayer.IReposatory;
using businessLayer.Reposatory;
using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using dataAccessLayer.sealedModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthnticationRepostory, AuthenticationRepository>();
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddSingleton<Roles>();
builder.Services.AddSingleton<ComplainsStatus>();
builder.Services.AddScoped<IStudents, StudentsRepository>();
builder.Services.AddScoped<IWorker, WorkerRepository>();





builder.Services.AddDbContext<MasterDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbString"))

);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(op=>

{
    op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["jwt:audiance"],
        ValidIssuer = builder.Configuration["jwt:issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]))

    };


}

); ;
builder.Services.AddHttpContextAccessor();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
