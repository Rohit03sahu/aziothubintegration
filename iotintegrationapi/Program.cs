var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .AddCommandLine(args)
        .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<AppSettings>();
builder.Services.AddTransient<IDevicePublisherClientToCloud, DevicePublisherClientToCloud>();
builder.Services.AddTransient<ICloudPublisherClientToDevice, CloudPublisherClientToDevice>();
builder.Services.AddTransient<IDeviceProvisionService, DeviceProvisionService>();
builder.Services.AddTransient<ICustomEventHubService,CustomEventHubService>();
builder.Services.AddTransient<IDBLayer, DBLayer>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          //WithOrigins("https://localhost:3001","http://localhost:3000")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod(); ;
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.Run();
app.UseSwaggerUI();
app.UseSwagger();
