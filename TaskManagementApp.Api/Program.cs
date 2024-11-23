using Serilog;
using TaskManagementApp.Api.BusinessLogics;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.DbExecutor;
using TaskManagementApp.Api.DbExecutor.Interface;
using TaskManagementApp.Api.Mappers;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models.ConnectionOption;
using TaskManagementApp.Api.Repositories;
using TaskManagementApp.Api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();



#region Splunk Integration
var serilog = new LoggerConfiguration().WriteTo.EventCollector(
    splunkHost: "http://localhost:8088/services/collector",
    eventCollectorToken: "1171a65b-cacd-41c2-862e-8a0dc5c737ab",
    index: "Idx_SplunkLog_TaskManagementApp"
        ).CreateLogger();
builder.Logging.AddSerilog(serilog);
#endregion 


#region DbExecutor
builder.Services.AddSingleton<IDbExecutor, DbExecutor>();
#endregion

#region BusinessLogic
builder.Services.AddScoped<ITaskItemLogic, TaskItemLogic>();
builder.Services.AddScoped<ITaskCategoryLogic, TaskCategoryLogic>();
builder.Services.AddScoped<ITaskPriorityLogic, TaskPriorityLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
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


#region CorsPolicy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTaskManagemtClientApp", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
#endregion
var app = builder.Build();
app.UseCors("AllowTaskManagemtClientApp");

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
