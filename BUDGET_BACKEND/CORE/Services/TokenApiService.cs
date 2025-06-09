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

        public TokenApiExtendDto? GetTokenApiById(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiById(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByUser(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByUser(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByStatus(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByStatus(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByCreationDateStatus(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByCreationDateStatus(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateStatus(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByExpirationDateStatus(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByUserStatus(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByUserStatus(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByCreationDateUserStatus(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByCreationDateUserStatus(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (tokenApisSearch.Count != 0)
            {
                return tokenApisSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TokenApiExtendDto> GetTokenApisByExpirationDateUserStatus(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            List<TokenApiExtendDto> tokenApisSearch = tokenApiRepository.GetTokenApisByExpirationDateUserStatus(tokenApi);

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (tokenApi == null || string.IsNullOrWhiteSpace(tokenApi.Token.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiByToken(tokenApi);

            if (tokenApiSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserDto? userSearch = userRepository.GetUserById(new UserDto { IdUser = tokenApi.IdUser }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = tokenApi.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            TokenApi saveTokenApi = new()
            {
                Token = tokenApi.Token,
                CreationDate = tokenApi.CreationDate,
                ExpirationDate = tokenApi.ExpirationDate,
                IdUser = userSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TokenApi>().Add(saveTokenApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveTokenApi), DateTime.Now, null);

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
            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiById(tokenApi) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (tokenApiDuplicado != null && tokenApiDuplicado.IdTokenApi != tokenApiSearch.IdTokenApi)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApi updateTokenApi = new()
            {
                IdTokenApi = tokenApiSearch.IdTokenApi,
                Token = tokenApi.Token,
                CreationDate = tokenApi.CreationDate,
                ExpirationDate = tokenApi.ExpirationDate,
                IdUser = tokenApiSearch.IdUser,
                IdStatus = tokenApiSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TokenApi>().Update(updateTokenApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(tokenApiSearch), JsonSerializer.Serialize(updateTokenApi), DateTime.Now, null);

            return tokenApi;
        }

        public TokenApiDto DeleteTokenApi(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiById(tokenApi) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = tokenApi.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (tokenApiSearch.IdStatus == tokenApi.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TokenApi deleteTokenApi = new()
            {
                IdTokenApi = tokenApiSearch.IdTokenApi,
                Token = tokenApiSearch.Token,
                CreationDate = tokenApiSearch.CreationDate,
                ExpirationDate = tokenApiSearch.ExpirationDate,
                IdUser = tokenApiSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TokenApi>().Update(deleteTokenApi);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(TokenApi).Name, Constants.Method.POST, JsonSerializer.Serialize(tokenApiSearch), JsonSerializer.Serialize(deleteTokenApi), DateTime.Now, null);

            return tokenApi;
        }

        #endregion

    }
}