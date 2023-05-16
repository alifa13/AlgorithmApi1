using AlgorithmApi.Application.Algorithms.FractionalKnapsack;
using AlgorithmApi.Application.DataStructures.Graph.Implementations;
using AlgorithmApi.Application.DataStructures.Graph.Interfaces;
using AlgorithmApi.Application.DataStructures.Job.Implementaions;
using AlgorithmApi.Application.DataStructures.Job.Interfaces;
using AlgorithmApi.Application.DataStructures.Matrix.Implementations;
using AlgorithmApi.Application.DataStructures.Matrix.Interfaces;
using AlgorithmApi.Application.DataStructures.Stuff.Implementations;
using AlgorithmApi.Application.DataStructures.Stuff.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJobOperations, JobOperations>();
builder.Services.AddScoped<IMatrixOperators, MatrixOperators>();
builder.Services.AddScoped<IGraphOperators, GraphOperators>();
builder.Services.AddScoped<IStuffOperators, StuffOperators>();
builder.Services.AddScoped<GFKnapsack , GFKnapsack>();
int a = 5;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
