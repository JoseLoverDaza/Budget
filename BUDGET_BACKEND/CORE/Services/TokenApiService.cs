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

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TokenApiService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TokenApiService : BaseService, ITokenApiService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public TokenApiService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public TokenApiExtendDto? GetTokenApiById(TokenApiDto tokenApi)
        {
            ITokenApiRepository tokenApiRepository = UnitOfWork.TokenApiRepository();
            TokenApiExtendDto? tokenApiSearch = tokenApiRepository.GetTokenApiById(tokenApi);

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
            return tokenApi;
        }

        #endregion

    }
}