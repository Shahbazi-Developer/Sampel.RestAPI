using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sampel.RestAPI.Endpoints.API.Authentication;
using Sampel.RestAPI.Endpoints.API.Extentions;
using Sampel.RestAPI.Infra.Data.Sql.Commands.Users;
using System.Text;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;
using Sampel.RestAPI.Core.Contracts.RestApiDemos.Users;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);

    // =====================================================
    // 1) JWT CONFIGURATION
    // =====================================================
    builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
    builder.Services.AddScoped<JwtTokenGenerator>();

    var jwtSection = builder.Configuration.GetSection("Jwt");
    var key = Encoding.UTF8.GetBytes(jwtSection["Key"]!);

    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSection["Issuer"],
                ValidAudience = jwtSection["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

    builder.Services.AddAuthorization();

    // =====================================================
    // 2) USER REPOSITORY
    // =====================================================
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    // =====================================================
    // 3) SWAGGER WITH JWT AUTH
    // =====================================================
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Sample REST API (Zamin + JWT)",
            Version = "v1"
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "توکن را به این شکل وارد کنید: Bearer {token}",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

    // =====================================================
    // 4) ZAMIN + SERILOG + PIPELINE
    // =====================================================
    var app = builder
        .AddZaminSerilog(o =>
        {
            o.ApplicationName = builder.Configuration.GetValue<string>("ApplicationName");
            o.ServiceId = builder.Configuration.GetValue<string>("ServiceId");
            o.ServiceName = builder.Configuration.GetValue<string>("ServiceName");
            o.ServiceVersion = builder.Configuration.GetValue<string>("ServiceVersion");
        })
        .ConfigureServices()
        .ConfigurePipeline();

    // =====================================================
    // 5) SWAGGER UI
    // =====================================================
    app.UseSwagger();
    app.UseSwaggerUI();

    // =====================================================
    // 6) AUTHENTICATION + AUTHORIZATION
    //    (حتماً بعد از ConfigurePipeline)
    // =====================================================
    app.UseAuthentication();
    app.UseAuthorization();

    // =====================================================
    // 7) RUN
    // =====================================================
    app.Run();
});
