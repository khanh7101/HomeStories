using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoriesWebAPI.Application.Interfaces;
using StoriesWebAPI.Application.Mappings;
using StoriesWebAPI.Application.Services;
using StoriesWebAPI.Application.Validators;
using StoriesWebAPI.Domain.Interfaces;
using StoriesWebAPI.Infrastructure.Data;
using StoriesWebAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ====================
// 1️⃣ Add services to container
// ====================

// Controllers
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper (load tất cả Profile trong Assembly Application)
builder.Services.AddAutoMapper(cfg => { },
    typeof(MappingProfile).Assembly);

// FluentValidation: tự động validate và hỗ trợ client-side
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<UserRegisterDtoValidator>();

// DbContext: MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)) // Thay bằng version MySQL của bạn
    )
);

// ====================
// 2️⃣ Dependency Injection: Repositories & Services
// ====================

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStoryRepository, StoryRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IContributorFollowRepository, ContributorFollowRepository>();
builder.Services.AddScoped<IStoryFollowRepository, StoryFollowRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IContributorFollowService, ContributorFollowService>();
builder.Services.AddScoped<IStoryFollowService, StoryFollowService>();

// Build & run App
var app = builder.Build();

// Middleware: Swagger chỉ bật dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // sinh swagger.json

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoriesWebAPI v1");
        c.RoutePrefix = string.Empty; // mở swagger ở root: https://localhost:{port}/
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
