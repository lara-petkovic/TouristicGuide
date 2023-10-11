using Microsoft.EntityFrameworkCore;
using TouristicGuide;
using TouristicGuide.Data;
using TouristicGuide.Interfaces;
using TouristicGuide.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddScoped<IUserQueriesRepository, UserQueriesRepository>();
builder.Services.AddScoped<IUserCommandsRepository, UserCommandsRepository>();
builder.Services.AddScoped<IAppointmentQueriesRepository, AppointmentQueriesRepository>();
builder.Services.AddScoped<IAppointmentCommandsRepository, AppointmentCommandsRepository>();
builder.Services.AddScoped<ITourQueriesRepository, TourQueriesRepository>();
builder.Services.AddScoped<ITourCommandsRepository, TourCommandsRepository>();
builder.Services.AddScoped<ILocationCommandsRepository, LocationCommandsRepository>();
builder.Services.AddScoped<ILocationQueriesRepository, LocationQueriesRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>           //added this
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
