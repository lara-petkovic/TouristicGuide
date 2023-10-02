using Microsoft.EntityFrameworkCore;
using TouristicGuide;
using TouristicGuide.Data;
using TouristicGuide.Interfaces;
using TouristicGuide.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();                          //added this



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>           //added this
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
); 

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")        //added this
    SeedData(app);

void SeedData(IHost app)                                        //added this
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
