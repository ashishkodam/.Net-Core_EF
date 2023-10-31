using Microsoft.EntityFrameworkCore;
using TodoItem.Repository;
using TodoItem.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddDbContext<TodoItemContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<TodoItemContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("todoItem_Postgres_Db")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI 
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

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
