namespace API.Extensions
{
    using CORE.Dto;
    using CORE.Interfaces.Repositories;

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

    public class MiddlewareAudit
    {

        #region Atributos y Propiedades

        private readonly RequestDelegate _next;
        
        #endregion

        public MiddlewareAudit(RequestDelegate next)
        {
            _next = next;           
        }

        #region Métodos y Funciones

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            if (path != null && (
                path.StartsWith("/swagger") ||
                path.StartsWith("/favicon") ||
                path.EndsWith(".css") ||
                path.EndsWith(".js") ||
                path.EndsWith(".png") ||
                path.EndsWith(".json")
            ))
            {
                await _next(context);
                return;
            }

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
                    var _userBudgetRepository = context.RequestServices.GetService<IUserBudgetRepository>();
                    UserBudgetExtendDto? userBudgetSearch = _userBudgetRepository!.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN });
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

        #endregion

    }
}