using PakketApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IPakketRepository, PakketRepository>();

var app = builder.Build();
app.MapControllers();
app.Run();

public partial class Program;
