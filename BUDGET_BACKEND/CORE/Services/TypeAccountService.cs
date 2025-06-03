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
               
        #endregion 

        #region Constructor

        public TypeAccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {           
        }

        #endregion

        #region Métodos y Funciones
               
        public TypeAccountExtendDto? GetTypeAccountById(int idTypeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            TypeAccountExtendDto? typeAccount = typeAccountRepository.GetTypeAccountById(idTypeAccount);

            if (typeAccount != null)
            {
                return typeAccount;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeAccountExtendDto? GetTypeAccountByName(string name)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            TypeAccountExtendDto? typeAccount = typeAccountRepository.GetTypeAccountByName(name);

            if (typeAccount != null)
            {
                return typeAccount;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<TypeAccountExtendDto> GetTypeAccountsByStatus(int idStatus)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            List<TypeAccountExtendDto> typeAccounts = typeAccountRepository.GetTypeAccountsByStatus(idStatus);

            if (typeAccounts.Count != 0)
            {
                return typeAccounts;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public TypeAccountExtendDto SaveTypeAccount(TypeAccountExtendDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (typeAccount == null || string.IsNullOrWhiteSpace(typeAccount.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(typeAccount.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountByName(typeAccount.Name.Trim());

            if (typeAccountSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(typeAccount.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            TypeAccount saveTypeAccount = new()
            {
                Name = typeAccount.Name.Trim(),
                Description = typeAccount.Description!.Trim(),
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TypeAccount>().Add(saveTypeAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return typeAccount;
        }

        public TypeAccountExtendDto UpdateTypeAccount(TypeAccountExtendDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            
            if (typeAccount == null || typeAccount.IdTypeAccount <= 0 || string.IsNullOrWhiteSpace(typeAccount.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (string.IsNullOrWhiteSpace(typeAccount.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccountExtendDto? typeAccountDuplicado = typeAccountRepository.GetTypeAccountByName(typeAccount.Name);
            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountById(typeAccount.IdTypeAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (typeAccountDuplicado != null && typeAccountDuplicado.IdTypeAccount != typeAccount.IdTypeAccount)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccount updateTypeAccount = new()
            {
                IdTypeAccount = typeAccountSearch.IdTypeAccount,
                Name = typeAccount.Name.Trim(),
                Description = typeAccount.Description!.Trim(),
                IdStatus = typeAccountSearch.IdStatus
            };

            UnitOfWork.BaseRepository<TypeAccount>().Update(updateTypeAccount);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return typeAccount;
        }

        public TypeAccountExtendDto DeleteTypeAccount(TypeAccountExtendDto typeAccount)
        {
            ITypeAccountRepository typeAccountRepository = UnitOfWork.TypeAccountRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            TypeAccountExtendDto? typeAccountSearch = typeAccountRepository.GetTypeAccountById(typeAccount.IdTypeAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(typeAccount.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusSearch.IdStatus == typeAccount.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            TypeAccount deleteTypeAccount = new()
            {
                IdTypeAccount = typeAccountSearch.IdTypeAccount,
                Name = typeAccountSearch.Name.Trim(),
                Description = typeAccountSearch.Description!.Trim(),
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