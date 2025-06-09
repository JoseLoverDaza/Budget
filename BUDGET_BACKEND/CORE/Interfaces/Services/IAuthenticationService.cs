using CORE.Dto;

namespace CORE.Interfaces.Services
{

    #region Librerias

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IAuthenticationService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IAuthenticationService
    {

        #region Métodos y Funciones

        public AuthenticationDto? Authentication(AuthenticationDto authentication);

        public AuthenticationDto? ValidateAuthentication(AuthenticationDto authentication);

        #endregion

    }
}