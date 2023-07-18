using Microsoft.EntityFrameworkCore;
using SchoolMgt;
using SchoolMgt.Data;
using SchoolMgt.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// CORS configuration
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
