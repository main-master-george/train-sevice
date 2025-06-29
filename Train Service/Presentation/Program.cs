using System.Text;
using Common.Mappers;
using CourseCompletionModule.Application.Repositories;
using CourseCompletionModule.Application.Services.Course;
using CourseCompletionModule.Application.Services.Module;
using CourseCompletionModule.Application.Services.Page;
using CourseCompletionModule.Application.Services.Test;
using CourseCompletionModule.Application.Services.TestCheck;
using CourseCompletionModule.Application.Services.TestPoint;
using CourseCompletionModule.Application.Services.Text;
using CourseManagementModule.Application.Repositories;
using CourseManagementModule.Application.Services.Course;
using CourseManagementModule.Application.Services.Module;
using CourseManagementModule.Application.Services.Page;
using CourseManagementModule.Application.Services.Test;
using CourseManagementModule.Application.Services.TestPoint;
using CourseManagementModule.Application.Services.Text;
using Infrastructure;
using Infrastructure.Mappers;
using Infrastructure.MappingProfiles;
using Infrastructure.MappingProfiles.CourseCompletion;
using Infrastructure.MappingProfiles.CourseManagement;
using Infrastructure.MappingProfiles.Moderation;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.CourseCompletion;
using Infrastructure.Repositories.CourseManagement;
using Infrastructure.Repositories.Moderation;
using Infrastructure.Services;
using Infrastructure.Services.CourseCompletion;
using Infrastructure.Storages;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModerationModule.Application.Repositories;
using ModerationModule.Application.Services;
using UserManagementModule.Application.Repositories;
using UserManagementModule.Application.Services;

var builder = WebApplication.CreateBuilder(args);

var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(defaultConnection)) throw new ArgumentNullException(nameof(defaultConnection), "Connection string cannot be null or empty.");

var allowedOrigins = builder.Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();

if (allowedOrigins is null || allowedOrigins.Length == 0)
    throw new ArgumentNullException(nameof(allowedOrigins),
        "CorsSettings:AllowedOrigins is not configured or is empty.");

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", cors =>
    {
        cors
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(defaultConnection);
});

builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddApiEndpoints();

var jwtSecretKey = builder.Configuration["Jwt:SecretKey"] ?? throw new ArgumentNullException();
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? throw new ArgumentNullException();
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? throw new ArgumentNullException();

var redisEndpoint = builder.Configuration["Redis:Endpoint"] ?? throw new ArgumentNullException();
var redisPassword = builder.Configuration["Redis:Password"] ?? throw new ArgumentNullException();

var smtpHost = builder.Configuration["Email:Smtp:Host"] ?? throw new ArgumentNullException();
var smtpPort = builder.Configuration["Email:Smtp:Port"] ?? throw new ArgumentNullException();
var smtpUsername = builder.Configuration["Email:Smtp:Username"] ?? throw new ArgumentNullException();
var smtpPassword = builder.Configuration["Email:Smtp:Password"] ?? throw new ArgumentNullException();
var smtpFrom = builder.Configuration["Email:Smtp:From"] ?? throw new ArgumentNullException();

builder.Services.AddControllers();
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = jwtAudience,
        ValidIssuer = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
    };
});

var redisStorage = new RedisStorage(redisEndpoint, redisPassword);

builder.Services.AddSingleton<RedisStorage>(_ => redisStorage);

builder.Services.AddSingleton<EmailService>(_ =>
    new EmailService(redisStorage, smtpHost, smtpPort, smtpUsername, smtpPassword, smtpFrom));

builder.Services.AddSingleton<JwtTokenGenerationService>(_ => new JwtTokenGenerationService(jwtSecretKey, jwtIssuer, jwtAudience));
builder.Services.AddScoped<AuthService>();

builder.Services.AddAutoMapper(
    typeof(UserManagementMappingProfile),
    typeof(CourseMappingProfile),
    typeof(ModuleMappingProfile),
    typeof(PageMappingProfile),
    typeof(TestMappingProfile),
    typeof(TestPointMappingProfile),
    typeof(TextMappingProfile),
    typeof(CourseCompletionMappingProfile),
    typeof(ModuleCompletionMappingProfile),
    typeof(PageCompletionMappingProfile),
    typeof(TestCompletionMappingProfile),
    typeof(TestPointCompletionMappingProfile),
    typeof(TextCompletionMappingProfile),
    typeof(RequestMappingProfile),
    typeof(ResponseMappingProfile));

builder.Services.AddSingleton<ICustomMapper, CustomMapper>();

builder.Services.AddScoped<IUserManagementRepository, UserManagementRepository>();

builder.Services.AddScoped<IUserManagementService, UserManagementService>();

builder.Services.AddScoped<ITextRepository, TextRepository>();
builder.Services.AddScoped<ITestPointRepository, TestPointRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IPageRepository, PageRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();
builder.Services.AddScoped<IUserModuleRepository, UserModuleRepository>();
builder.Services.AddScoped<IUserTestRepository, UserTestRepository>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IResponseRepository, ResponseRepository>();

builder.Services.AddScoped<ITextService, TextService>();
builder.Services.AddScoped<ITestPointService, TestPointService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<ICourseIntegrationService, CourseIntegrationService>();
builder.Services.AddScoped<IModuleIntegrationService, ModuleIntegrationService>();
builder.Services.AddScoped<IPageIntegrationService, PageIntegrationService>();
builder.Services.AddScoped<ITestIntegrationService, TestIntegrationService>();
builder.Services.AddScoped<ITestCheckingService, TestCheckingService>();
builder.Services.AddScoped<ITestPointIntegrationService, TestPointIntegrationService>();
builder.Services.AddScoped<ITextIntegrationService, TextIntegrationService>();

builder.Services.AddScoped<ICourseCompletionService, CourseCompletionService>();
builder.Services.AddScoped<IModuleCompletionService, ModuleCompletionService>();
builder.Services.AddScoped<IPageCompletionService, PageCompletionService>();
builder.Services.AddScoped<ITestCompletionService, TestCompletionService>();
builder.Services.AddScoped<ITestPointCompletionService, TestPointCompletionService>();
builder.Services.AddScoped<ITextCompletionService, TextCompletionService>();

builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IResponseService, ResponseService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();