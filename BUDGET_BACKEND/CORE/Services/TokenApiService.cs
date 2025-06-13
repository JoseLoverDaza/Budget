namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TokenApiService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TokenApiService : BaseService, ITokenApiService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public TokenApiService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public TokenApiExtendDto? GetTokenApiByIdTokenApi(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiByIdTokenApi(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApiSearch != null)
            {
                return tokenApiSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TokenApiExtendDto? GetTokenApiByToken(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiByToken(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApiSearch != null)
            {
                return tokenApiSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByCreationDate(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByCreationDate(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByUserBudget(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByUserBudget(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByStatusBudget(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByStatusBudget(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByCreationDateStatusBudget(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByCreationDateStatusBudget(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateStatusBudget(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByExpirationDateStatusBudget(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByUserBudgetStatusBudget(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByCreationDateUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByCreationDateUserBudgetStatusBudget(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByExpirationDateUserBudgetStatusBudget(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(tokenApi), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TokenApiDto SaveTokenApi(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (tokenApi == null || string.IsNullOrWhiteSpace(tokenApi.Token.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiByToken(tokenApi);

            if (tokenApiSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByIdUserBudget(new UserBudgetDto { IdUserBudget = tokenApi.IdUserBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = tokenApi.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            TokenApi saveTokenApi = new()
            {
                Token = tokenApi.Token,               
                ExpirationDate = tokenApi.ExpirationDate,
                IdUserBudget = userBudgetSearch.IdUserBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = tokenApi.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = tokenApi.ModificationDate
            };

            UnitOfWork.BaseRepository<TokenApi>().Add(saveTokenApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Account).Name, Constants.EntityAction.SAVE, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveTokenApi), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return tokenApi;
        }

        public TokenApiDto UpdateTokenApi(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();

            if (tokenApi == null || tokenApi.IdTokenApi <= 0 || string.IsNullOrWhiteSpace(tokenApi.Token.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApiExtendDto? tokenApiDuplicado = tokenApiRepository.GetTokenApiByToken(tokenApi);
            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiByIdTokenApi(tokenApi) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (tokenApiDuplicado != null && tokenApiDuplicado.IdTokenApi != tokenApiSearch.IdTokenApi)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApi updateTokenApi = new()
            {
                IdTokenApi = tokenApiSearch.IdTokenApi,
                Token = tokenApi.Token,                
                ExpirationDate = tokenApi.ExpirationDate,
                IdUserBudget = tokenApiSearch.IdUserBudget,
                IdStatusBudget = tokenApiSearch.IdStatusBudget,
                CreationUser = tokenApiSearch.CreationUser,
                CreationDate = tokenApiSearch.CreationDate,
                ModificationUser = tokenApiSearch.ModificationUser,
                ModificationDate = tokenApi.ModificationDate
            };

            UnitOfWork.BaseRepository<TokenApi>().Update(updateTokenApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.UPDATE, JsonSerializer.Serialize(tokenApiSearch), JsonSerializer.Serialize(updateTokenApi), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return tokenApi;
        }

        public TokenApiDto DeleteTokenApi(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiByIdTokenApi(tokenApi) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = tokenApi.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (tokenApiSearch.IdStatusBudget == tokenApi.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApi deleteTokenApi = new()
            {
                IdTokenApi = tokenApiSearch.IdTokenApi,
                Token = tokenApiSearch.Token,                
                ExpirationDate = tokenApiSearch.ExpirationDate,
                IdUserBudget = tokenApiSearch.IdUserBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget
            };

            UnitOfWork.BaseRepository<TokenApi>().Update(deleteTokenApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.EntityAction.DELETE, JsonSerializer.Serialize(tokenApiSearch), JsonSerializer.Serialize(deleteTokenApi), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return tokenApi;
        }

        #endregion

    }
}