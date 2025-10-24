using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Week3Task1.Services;
using Week3Task1.Services.Interfaces;
using Week3Task1.Repositories;
using Week3Task1.Repositories.Interfaces;
using Week3Task1.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Week3Task1",
        Version = "v1",
        Description = "Library Management System"
    });
});
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Week3Task1 API v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseExceptionHandler("/error");

app.Map("/error", (HttpContext context) =>
{
    var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;

    return ex switch
    {
        Week3Task1.Exceptions.ValidationException vEx => Results.Problem(
            detail: vEx.Message,
            statusCode: vEx.StatusCode,
            title: "Validation failed."),

        NotFoundException nEx => Results.Problem(
            detail: nEx.Message,
            statusCode: nEx.StatusCode,
            title: "Resource not found."),

        ArgumentException argEx => Results.Problem(
            detail: argEx.Message,
            statusCode: 400,
            title: "Invalid argument."),

        _ => Results.Problem(
            detail: ex?.Message ?? "An unexpected error occured",
            statusCode: 500,
            title: "Internal Server Error.")
    };
});
app.UseHttpsRedirection();
app.MapControllers();

app.Run();