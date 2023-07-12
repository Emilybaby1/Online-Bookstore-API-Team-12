using AutoMapper;
using BookStore__Management_system.Data;
using BookStore__Management_system.Helpers;
using BookStore__Management_system.Repository;
using Cqrs.Hosts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddAutoMapper(typeof(ApplicationMapper));


// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
