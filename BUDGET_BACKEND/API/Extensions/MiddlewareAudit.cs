namespace API.Extensions
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: MiddlewareAudit   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class MiddlewareAudit(RequestDelegate next, ILogger<MiddlewareAudit> logger)
    {

        #region Atributos y Propiedades

        private readonly RequestDelegate _next = next;
        
        #endregion

        #region Métodos y Funciones

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString();

            if (context.Request.Headers.TryGetValue("X-Forwarded-For", out Microsoft.Extensions.Primitives.StringValues value))
            {
                ip = value.ToString().Split(',')[0].Trim();
            }

            var usuario = context.User.Identity?.Name ?? "Anónimo";
            var endpoint = context.Request.Path;
            var metodo = context.Request.Method;
            var fecha = DateTime.UtcNow;
                                  
            await _next(context);
        }

        #endregion

    }
}