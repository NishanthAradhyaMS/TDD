using ToDoApp.Constants;
using ToDoApp.Services.Interface;
using ToDoApp.Services;
using TDDPOC.Repository;
using ToDoApp.Repository;
using ToDoApp.Models;
using ToDoApp.Repository.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDBSetting>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapHealthChecks(ApiRoutes.Healthy);
app.MapControllers();
app.Run();
public partial class Program { }
