namespace API.Extensions
{

    #region Librerias

    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using System.Runtime.InteropServices;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: MiddlewareAudit   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class MiddlewareAudit(RequestDelegate next)
    {

        #region Atributos y Propiedades

        private readonly RequestDelegate _next = next;

        #endregion

        #region Métodos y Funciones

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString();
            if (context.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor))
            {
                ip = forwardedFor.ToString().Split(',')[0].Trim();
            }

            DateTime fechaUtc = DateTime.UtcNow;
            TimeZoneInfo zonaHoraria = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime fechaLocal = TimeZoneInfo.ConvertTimeFromUtc(fechaUtc, zonaHoraria);

            var endpoint = context.Request.Path;
            var metodo = context.Request.Method;
            var agente = context.Request.Headers.UserAgent.ToString();
            var fecha = fechaLocal;

            try
            {
                await _next(context);
            }
            catch (Exception)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            finally
            {
                if (context.RequestServices.GetService(typeof(IAuditApiService)) is IAuditApiService auditService)
                {
                    var auditDto = new AuditDto
                    {
                        Host = ip,
                        Endpoint = endpoint,
                        Method = metodo,
                        Agent = agente,
                        CreationDate = fecha
                    };

                    auditService.SaveAudit(auditDto);
                }
            }
        }

        #endregion

    }
}