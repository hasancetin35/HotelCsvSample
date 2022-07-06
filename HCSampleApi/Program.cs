
using DataAccess.DBContext;
using DataAccess.Repository;
using HCSampleApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));
//builder.Services.AddScoped<IHotelService, HotelManager>();
builder.Services.AddControllers();
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

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
