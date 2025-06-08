namespace API.Controllers
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Services;   
    using CORE.Utils;   
    using Domain.Dto.Common;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuthenticationController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IAuthenticationService _authenticationService;

        #endregion

        #region Constructor

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("Authentication")]
        [SwaggerOperation(Summary = "Authentication")]
        public ResponseDto Authentication(AuthenticationDto authentication)
        {
            try
            {
                response.Data = _authenticationService.Authentication(authentication);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("ValidateAuthentication")]
        [SwaggerOperation(Summary = "Validate Authentication")]
        public ResponseDto ValidateAuthentication(AuthenticationDto authentication)
        {
            try
            {
                response.Data = _authenticationService.ValidateAuthentication(authentication);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        #endregion

    }
}