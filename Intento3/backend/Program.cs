using backend.repositories;
using backend.services;
using backend.services.interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PetRepository>();
builder.Services.AddSingleton<PersonRepository>();
builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IPetService, PetServices>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalhost",
      builder => builder.WithOrigins("http://localhost:5173")
          .AllowAnyMethod()
          .AllowAnyHeader()
  );

});

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowLocalhost");

app.Run();