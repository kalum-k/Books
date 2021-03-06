using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//database
builder.Services.AddDbContext<BookContext>(x => x.UseSqlite("Data source=book.db"));
builder.Services.AddScoped<IBookRepository, BookRepository > ();

//database
builder.Services.AddDbContext<UserContext>(y => y.UseSqlite("Data source=user.db"));
builder.Services.AddScoped<IUserRepository, UserRepository>();


//razorpages
builder.Services.AddRazorPages();

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
app.MapRazorPages();

app.Run();
