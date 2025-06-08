namespace CORE.Services
{
    
    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;   
    using System.Runtime.InteropServices;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuthenticationService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuthenticationService : BaseService, IAuthenticationService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public AuthenticationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public AuthenticationDto? Authentication(AuthenticationDto authentication)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();

            if (authentication == null || string.IsNullOrWhiteSpace(authentication.Username.Trim()) || string.IsNullOrWhiteSpace(authentication.Password.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userSearch = userRepository.GetUserByUsername(new UserDto { Username = authentication.Username.Trim() });

            if (userSearch == null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
           
            return authentication;
        }

        public AuthenticationDto? ValidateAuthentication(AuthenticationDto authentication)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();

            if (authentication == null || string.IsNullOrWhiteSpace(authentication.Username.Trim()) || string.IsNullOrWhiteSpace(authentication.Password.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userSearch = userRepository.GetUserByUsername(new UserDto { Username = authentication.Username.Trim() });

            if (userSearch == null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            return authentication;
        }

        #endregion

    }
}