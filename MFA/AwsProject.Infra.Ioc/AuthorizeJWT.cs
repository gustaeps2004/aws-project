using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AwsProject.Infra.Ioc
{
    public static class AuthorizeJWT
    {
        public static IServiceCollection AddAuthorizeJwtConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(auth =>
            {
                auth.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth - MFA", Version = "v1" });

                auth.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT authorization header using schema. \r\n\r\n Enter 'Bearer'[space] and your token. \r\n\r\nExample: \'Bearer 123abcdef\'"
                });
                auth.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] {  }
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = Environment.GetEnvironmentVariable("AUTH_LOGIN_AUDIENCE"),
                    ValidIssuer = Environment.GetEnvironmentVariable("AUTH_LOGIN_ISSUER"),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("AUTH_LOGIN_SECRET")))
                });

            return services;
        }
    }
}
