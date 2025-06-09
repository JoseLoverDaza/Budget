namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Entities;
    using Microsoft.Extensions.Configuration;
    using System.Runtime.InteropServices;
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuthenticationService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AuthenticationService : BaseService, IAuthenticationService
    {

        #region Atributos y Propiedades

        private readonly IConfiguration _configuration;
        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public AuthenticationService(IUnitOfWork unitOfWork, IConfiguration configuration, ILogApiService logApiService) : base(unitOfWork)
        {
            _configuration = configuration;
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public AuthenticationDto? Authentication(AuthenticationDto authentication)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (authentication == null || string.IsNullOrWhiteSpace(authentication.Username.Trim()) || string.IsNullOrWhiteSpace(authentication.Password.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userSearch = (userRepository.GetUserByUsername(new UserDto { Username = authentication.Username }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL));
            StatusDto? statusSearch = statusRepository.GetStatusByName(new StatusDto { Name = Constants.Status.ACTIVO }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (!PasswordHash.VerifyPassword(authentication.Password, userSearch.Password))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            string secretKey = _configuration["Encryption:SecretKey"]!;
            string sToken = PasswordHash.GenerateJwtToken(userSearch, secretKey);

            if (string.IsNullOrWhiteSpace(secretKey) || string.IsNullOrWhiteSpace(sToken))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApi saveTokenApi = new()
            {
                Token = sToken,
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(1),
                IdUser = userSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TokenApi>().Add(saveTokenApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
                        
            authentication.Token = sToken;
            authentication.CreationDate = DateTime.Now;
            authentication.ExpirationDate = DateTime.Now.AddDays(1);
            authentication.IsAuthenticated = true;

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.TOKEN, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(authentication), DateTime.Now, statusSearch.IdStatus);

            return authentication;
        }

        public AuthenticationDto? ValidateAuthentication(AuthenticationDto authentication)
        {
            IUserRepository userRepository = UnitOfWork.UserRepository();
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (authentication == null || string.IsNullOrWhiteSpace(authentication.Token.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApiExtendDto? tokenApiSearch = (tokenApiRepository.GetTokenApiByToken(new TokenApiDto { Token = authentication.Token.Trim() }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL));
            UserExtendDto? userSearch = (userRepository.GetUserById(new UserDto { IdUser = tokenApiSearch.IdUser }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL));
            StatusDto? statusSearch = statusRepository.GetStatusByName(new StatusDto { Name = Constants.Status.ACTIVO }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (userSearch.IdStatus != statusSearch.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
                        
            authentication.Username = userSearch.Username;
            authentication.Password = string.Empty;
            authentication.CreationDate = tokenApiSearch.CreationDate;
            authentication.ExpirationDate = tokenApiSearch.ExpirationDate;
            authentication.IsAuthenticated = tokenApiSearch.ExpirationDate >= DateTime.Now;

            _logApiService.TraceLog(typeof(Account).Name, Constants.Method.VERIFY, JsonSerializer.Serialize(tokenApiSearch), JsonSerializer.Serialize(authentication), DateTime.Now, statusSearch.IdStatus);

            return authentication;
        }

        

        #endregion

    }
}