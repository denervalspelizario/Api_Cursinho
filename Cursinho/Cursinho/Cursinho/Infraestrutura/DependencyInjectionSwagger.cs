using Microsoft.OpenApi.Models;

namespace Cursinho.Infraestrutura
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // passando as confgs de segurança
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Name = "Autorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT", 
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "JSON Web Token",
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference()
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            return services;
        }
    }
}
