
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapDefaultEndpoints();

app.UseFileServer();

app.Run();