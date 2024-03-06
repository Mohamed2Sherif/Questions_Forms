using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using QuetionsCRUD.api.Data;
using QuetionsCRUD.api.Repositories;
using QuetionsCRUD.api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<QuestionsCrudDbContext>(opt => opt.
        UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.WithOrigins("http://localhost:3000","http://localhost:80").AllowAnyMethod().
    WithHeaders(HeaderNames.ContentType));
app.UseAuthorization();

app.MapControllers();

app.Run();