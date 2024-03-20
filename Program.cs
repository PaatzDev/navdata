using navdata.parsers;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => {
    options.Limits.MaxRequestBodySize = long.MaxValue;
});

builder.Services.AddScoped<Arinc424Parser>();
builder.Services.AddScoped<StreamedDataHandler>();

builder.Services.AddRouting(options => 
    options.LowercaseUrls = true
);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

