using Microsoft.EntityFrameworkCore;                                                         //I added this
using Microsoft.OpenApi.Models;
using TodoApi.Models;
using Touristic_App.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("GuidesList"));   //I added this
builder.Services.AddDbContext<TourContext>(opt => opt.UseInMemoryDatabase("ToursList"));     //I added this


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("guide_v1", new OpenApiInfo { Title = "Touristic Guide API", Description = "Here you can see all the options for guides", Version = "guide_v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/guide_v1/swagger.json", "TouristicGuide V1");
    });
}

app.UseAuthorization();  //Ovaj middleware dodaje podršku za autentikaciju i autorizaciju, ali u ovom kodu ne postoje konkretni pravila za autorizaciju, pa æe svi zahtjevi biti odobreni.

app.MapControllers();

app.Run();
