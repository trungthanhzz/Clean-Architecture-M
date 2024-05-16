using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher.API;
using MISA.WebFresher.Application;
using MISA.WebFresher.Domain;
using MISA.WebFresher.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .WithOrigins("http://localhost:8080") // Địa chỉ gốc của ứng dụng Vue.js
            .WithOrigins("https://localhost:7082") // Địa chỉ máy chủ API (HTTPS)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values.SelectMany(x => x.Errors);
        var errorList = errors.Select(error => error.ErrorMessage).ToList();
        return new BadRequestObjectResult(new BaseException()
        {
            ErrorCode = 400,
            UserMsg = "",
            DevMsg = "",
            TraceId = "",
            MoreInfo = "",
            Errors = errorList
        }.ToString() ?? "");
    };
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.Converters.Add(new LocalTimeZoneConverter());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Khai báo Dependency Injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeValidate, EmployeeValidate>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS middleware
app.UseCors("AllowSpecificOrigin");


app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
