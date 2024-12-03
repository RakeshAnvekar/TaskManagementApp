using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManagementApp.Api.Autentication;
using TaskManagementApp.Api.BusinessLogics;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.DbExecutor;
using TaskManagementApp.Api.DbExecutor.Interface;
using TaskManagementApp.Api.Mappers;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Middlewares;
using TaskManagementApp.Api.Models.ConnectionOption;
using TaskManagementApp.Api.Repositories;
using TaskManagementApp.Api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();

// Add services to the container.


#region DbExecutor
builder.Services.AddSingleton<IDbExecutor, DbExecutor>();
#endregion

#region BusinessLogic
builder.Services.AddScoped<ITaskItemLogic, TaskItemLogic>();
builder.Services.AddScoped<ITaskCategoryLogic, TaskCategoryLogic>();
builder.Services.AddScoped<ITaskPriorityLogic, TaskPriorityLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
#endregion

#region Repository
builder.Services.AddSingleton<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddSingleton<ITaskCategoryRepository, TaskCategoryRepository>();
builder.Services.AddSingleton<ITaskPriorityRepository, TaskPriorityRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
#endregion

#region Mappers
builder.Services.AddSingleton<ITaskItemMapper, TaskItemMapper>();
builder.Services.AddSingleton<ITaskCategoryMapper, TaskCategoryMapper>();
builder.Services.AddSingleton<ITaskPriorityMapper, TaskPriorityMapper>();
builder.Services.AddSingleton<IUserMapper, UserMapper>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ConnectionOption>(builder.Configuration.GetSection("ConnectionOption"));

#region Jwt Token Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters { 
    ValidateIssuer=true,
    ValidateAudience=true,
    ValidateLifetime=true,
    ValidateIssuerSigningKey=true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };


});
#endregion

#region CorsPolicy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTaskManagemtClientApp", policy =>
    {
        policy.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod()
       .WithExposedHeaders("Authorization", "Custom-Header");
    });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<HealtCheckMiddleware>();

app.UseRouting();
app.UseCors("AllowTaskManagemtClientApp");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
