namespace API.Extensions
{
    using CORE.Dto;

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

            var endpointurl = context.Request.Path;
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
                    var userBudget = context.RequestServices.GetService(typeof(IUserBudgetService));
                    if (userBudget is IUserBudgetService userBudgetService)
                    {
                        UserBudgetExtendDto? userBudgetSearch = userBudgetService.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN });
                        if (userBudgetSearch != null)
                        {
                            var auditApiDto = new AuditApiDto
                            {
                                Host = ip,
                                EndpointUrl = endpointurl,
                                Method = metodo,
                                Agent = agente,
                                CreationDate = fecha,
                                CreationUser = userBudgetSearch.IdUserBudget,
                                ModificationDate = fecha,
                                ModificationUser = userBudgetSearch.IdUserBudget
                            };
                            auditService.SaveAuditApi(auditApiDto);
                        }
                    }                    
                }
            }
        }

        #endregion

    }
}