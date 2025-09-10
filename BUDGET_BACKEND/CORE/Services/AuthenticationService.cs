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
    using static CORE.Utils.Constants;

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
            IUserBudgetRepository userRepository = UnitOfWork.UserBudgetRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            if (authentication == null || string.IsNullOrWhiteSpace(authentication.Username.Trim()) || string.IsNullOrWhiteSpace(authentication.EncryptedPassword.Trim()))
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userSearch = (userRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = authentication.Username }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL));
            StatusBudgetDto? statusBudgetSearch = statusRepository.GetStatusBudgetByNameStatus(new StatusBudgetDto { NameStatus = Constants.Status.ACTIVO }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (!PasswordHash.VerifyPassword(authentication.EncryptedPassword, userSearch.EncryptedPassword))
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }

            TimeZoneInfo colombiaZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime dNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, colombiaZone);
            string secretKey = _configuration["Encryption:SecretKey"]!;
            string issuer = _configuration["Encryption:Issuer"]!;
            string audience = _configuration["Encryption:Audience"]!;
            string sToken = PasswordHash.GenerateJwtToken(userSearch, secretKey, issuer, audience, dNow);
            
            if (string.IsNullOrWhiteSpace(secretKey) || string.IsNullOrWhiteSpace(sToken))
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }

            TokenApi saveTokenApi = new()
            {
                Token = sToken,
                CreationDate = dNow,
                ExpirationDate = dNow.AddDays(1),
                IdUserBudget = userSearch.IdUserBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget
            };

            UnitOfWork.BaseRepository<TokenApi>().Add(saveTokenApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }
                
            authentication.IdUserBudget = userSearch.IdUserBudget;
            authentication.Username = userSearch.Username;
            authentication.EncryptedPassword = userSearch.EncryptedPassword;
            authentication.Token = sToken;
            authentication.CreationDate = saveTokenApi.CreationDate;
            authentication.ExpirationDate = saveTokenApi.ExpirationDate;
            authentication.IsAuthenticated = true;

            _logApiService.TraceLog(typeof(TokenApi).Name, MethodHttp.TOKEN, JsonSerializer.Serialize(General.JSON_EMPTY), JsonSerializer.Serialize(General.JSON_EMPTY), Json.SerializeWithoutNulls(authentication), DateTime.Now, statusBudgetSearch.IdStatusBudget);

            return authentication;
        }

        public AuthenticationDto? ValidateAuthentication(AuthenticationDto authentication)
        {
            IUserBudgetRepository userRepository = UnitOfWork.UserBudgetRepository();
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusBudgetRepository();

            if (authentication == null || string.IsNullOrWhiteSpace(authentication.Token.Trim()))
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }

            TokenApiExtendDto? tokenApiSearch = (tokenApiRepository.GetTokenApiByToken(new TokenApiDto { Token = authentication.Token.Trim() }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL));
            UserBudgetExtendDto? userSearch = (userRepository.GetUserBudgetByIdUserBudget(new UserBudgetDto { IdUserBudget = tokenApiSearch.IdUserBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL));
            StatusBudgetDto? statusBudgetSearch = statusRepository.GetStatusBudgetByNameStatus(new StatusBudgetDto { NameStatus = Constants.Status.ACTIVO }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (userSearch.IdStatusBudget != statusBudgetSearch.IdStatusBudget)
            {
                throw new ExternalException(General.MESSAGE_GENERAL);
            }
                        
            authentication.Username = userSearch.Username;
            authentication.EncryptedPassword = string.Empty;
            authentication.CreationDate = tokenApiSearch.CreationDate;
            authentication.ExpirationDate = tokenApiSearch.ExpirationDate;
            authentication.IsAuthenticated = tokenApiSearch.ExpirationDate >= DateTime.Now;

            _logApiService.TraceLog(typeof(TokenApi).Name, MethodHttp.VERIFY, JsonSerializer.Serialize(General.JSON_EMPTY), JsonSerializer.Serialize(General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApiSearch), DateTime.Now, statusBudgetSearch.IdStatusBudget);

            return authentication;
        }
        
        #endregion

    }
}