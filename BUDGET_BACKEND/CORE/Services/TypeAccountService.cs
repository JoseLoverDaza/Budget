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
    /// Nombre: TypeAccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeAccountService : BaseService, ITypeAccountService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public TypeAccountService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public TypeAccountExtendDto? GetTypeAccountById(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountById(typeAccount);

            if (typeAccountSearch != null)
            {
                return typeAccountSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeAccountExtendDto? GetTypeAccountByName(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByName(typeAccount);

            if (typeAccountSearch != null)
            {
                return typeAccountSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TypeAccountExtendDto> GetTypeAccountsByStatus(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            List<TypeAccountExtendDto> typeAccountsSearch = typeAccountRepository.GetTypeAccountsByStatus(typeAccount);

            if (typeAccountsSearch.Count != 0)
            {
                return typeAccountsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeAccountDto SaveTypeAccount(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (typeAccount == null || string.IsNullOrWhiteSpace(typeAccount.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByName(typeAccount);

            if (typeAccountSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = typeAccount.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            TypeAccount saveTypeAccount = new()
            {
                Name = typeAccount.Name.Trim(),
                Description = typeAccount.Description?.Trim() ?? string.Empty,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TypeAccount>().Add(saveTypeAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return typeAccount;
        }

        public TypeAccountDto UpdateTypeAccount(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();

            if (typeAccount == null || typeAccount.IdTypeAccount <= 0 || string.IsNullOrWhiteSpace(typeAccount.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccountExtendDto? typeAccountDuplicado = typeAccountRepository.GetTypeAccountByName(typeAccount);
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountById(typeAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeAccountDuplicado != null && typeAccountDuplicado.IdTypeAccount != typeAccount.IdTypeAccount)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccount updateTypeAccount = new()
            {
                IdTypeAccount = typeAccountSearch.IdTypeAccount,
                Name = typeAccount.Name.Trim(),
                Description = typeAccount.Description?.Trim() ?? string.Empty,
                IdStatus = typeAccountSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TypeAccount>().Update(updateTypeAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return typeAccount;
        }

        public TypeAccountDto DeleteTypeAccount(TypeAccountDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountById(typeAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = typeAccount.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeAccountSearch.IdStatus == typeAccount.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccount deleteTypeAccount = new()
            {
                IdTypeAccount = typeAccountSearch.IdTypeAccount,
                Name = typeAccountSearch.Name.Trim(),
                Description = typeAccountSearch.Description?.Trim() ?? string.Empty,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TypeAccount>().Update(deleteTypeAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return typeAccount;
        }

        #endregion

    }
}