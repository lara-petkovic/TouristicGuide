using Microsoft.EntityFrameworkCore;                                                         //I added this
using TodoApi.Models;
using Touristic_App.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>                                            //I added this
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<GuideContext>(opt => opt.UseInMemoryDatabase("GuidesList"));   //I added this

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

app.UseAuthorization();  //Ovaj middleware dodaje podršku za autentikaciju i autorizaciju, ali u ovom kodu ne postoje konkretni pravila za autorizaciju, pa æe svi zahtjevi biti odobreni.

app.MapControllers();

app.Run();
