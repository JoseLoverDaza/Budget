namespace API.Extensions
{

    #region Librerias

    using Microsoft.OpenApi.Models;
    using System.Diagnostics.CodeAnalysis;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: SwaggerServiceExtensions   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [ExcludeFromCodeCoverage]
    public static class SwaggerServiceExtensions
    {

        #region Métodos y Funciones

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BUDGET_BACKEND",
                    Version = "v1",
                    Description = "Servicio de Budget"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor ingresa el token JWT en formato **Bearer {token}**",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            }, new List<string> { }

                        }
                    });
            });
            return services;
        }

        /// <summary>
        /// Descripción: Método que define la documentación de Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerGen(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", String.Format("BUDGET_BACKEND.API {0}", "v1")));
            return app;
        }

        #endregion

    }
}
