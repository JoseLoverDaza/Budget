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
    /// Nombre: DepositService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class DepositService : BaseService, IDepositService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public DepositService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositById(int idDeposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            DepositExtendDto? deposit = depositRepository.GetDepositById(idDeposit);

            if (deposit != null)
            {
                return deposit;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonth(int year, int month)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByYearMonth(year, month);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(int year, int month, int idAccount)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByYearMonthAccount(year, month, idAccount);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthStatus(int year, int month, int idStatus)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByYearMonthStatus(year, month, idStatus);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUser(int year, int month, int idUser)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByYearMonthUser(year, month, idUser);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByUser(int idUser)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByUser(idUser);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByAccount(int idAccount)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByAccount(idAccount);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByStatus(int idStatus)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByStatus(idStatus);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByUserStatus(int idUser, int idStatus)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByUserStatus(idUser, idStatus);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByAccountStatus(int idAccount, int idStatus)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByAccountStatus(idAccount, idStatus);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public DepositExtendDto SaveDeposit(DepositExtendDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();            
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (deposit == null || string.IsNullOrWhiteSpace(deposit.Amount.ToString().Trim()) || deposit.Year <= 0 || deposit.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
                     
            AccountExtendDto? accountSearch = accountRepository.GetAccountById(deposit.IdAccount) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserExtendDto? userSearch = userRepository.GetUserById(deposit.IdUser) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(deposit.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            List<DepositExtendDto>? depositSearch = depositRepository.GetDepositsByYearMonthUserAccount(deposit.Year, deposit.Month, userSearch.IdUser, accountSearch.IdAccount);

            if (depositSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
                       
            Deposit saveDeposit = new()
            {
                Year = deposit.Year,
                Month = deposit.Month, 
                Amount = deposit.Amount,
                IdUser = userSearch.IdUser,
                IdAccount = accountSearch.IdAccount,                
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Deposit>().Add(saveDeposit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return deposit;
        }

        public DepositExtendDto UpdateDeposit(DepositExtendDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();

            if (deposit == null || string.IsNullOrWhiteSpace(deposit.Amount.ToString().Trim()) || deposit.Year <= 0 || deposit.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<DepositExtendDto>? deposits = depositRepository.GetDepositsByYearMonthUserAccount(deposit.Year, deposit.Month, deposit.IdUser, deposit.IdAccount);
            DepositExtendDto? depositDuplicado = deposits.Count != 0 ? deposits.FirstOrDefault() : new DepositExtendDto();
            DepositExtendDto? depositSearch = depositRepository.GetDepositById(deposit.IdDeposit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (depositDuplicado != null && depositDuplicado.IdDeposit != depositSearch.IdDeposit)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Deposit updateDeposit = new()
            {
                IdDeposit = depositSearch.IdDeposit,
                Year = depositSearch.Year,
                Month = depositSearch.Month,
                Amount = deposit.Amount,
                IdUser = depositSearch.IdUser,
                IdAccount = depositSearch.IdAccount,
                IdStatus = depositSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Deposit>().Update(updateDeposit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return deposit;
        }

        public DepositExtendDto DeleteDeposit(DepositExtendDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            DepositExtendDto? depositSearch = depositRepository.GetDepositById(deposit.IdDeposit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Deposit deleteDeposit = new()
            {
                IdDeposit = depositSearch.IdDeposit,
                Year = depositSearch.Year,
                Month = depositSearch.Month,
                Amount = depositSearch.Amount,
                IdUser = depositSearch.IdUser,
                IdAccount = depositSearch.IdAccount,               
                IdStatus = Constants.Status.INACTIVO
            };

            UnitOfWork.BaseRepository<Deposit>().Update(deleteDeposit);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return deposit;
        }

        #endregion

    }
}