using Identity.API;
using Identity.API.Data;
using Identity.API.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.InitialiseDatabaseAsync();
}

//builder.Services.AddSwaggerGen(opt =>
//{
//    //opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    //{
//    //    In = ParameterLocation.Header,
//    //    Description = "Please enter token",
//    //    Name = "Authorization",
//    //    Type = SecuritySchemeType.Http,
//    //    BearerFormat = "JWT",
//    //    Scheme = "bearer"
//    //});

//    //opt.AddSecurityRequirement(new OpenApiSecurityRequirement
//    //{
//    //    {
//    //        new OpenApiSecurityScheme
//    //        {
//    //            Reference = new OpenApiReference
//    //            {
//    //                Type=ReferenceType.SecurityScheme,
//    //                Id="Bearer"
//    //            }
//    //        },
//    //        new string[]{}
//    //    }
//    //});
//});

app.MapIdentityApi<ApplicationUser>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
