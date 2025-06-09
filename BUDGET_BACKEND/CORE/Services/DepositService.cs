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

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public DepositService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositById(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            DepositExtendDto? depositSearch = depositRepository.GetDepositById(deposit);

            if (depositSearch != null)
            {
                return depositSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonth(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearMonth(deposit);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearUser(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearUser(deposit);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByMonthUser(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByMonthUser(deposit);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUser(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearMonthUser(deposit);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearMonthAccount(deposit);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthStatus(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> depositsSearch = depositRepository.GetDepositsByYearMonthStatus(deposit);

            if (depositsSearch.Count != 0)
            {
                return depositsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByYearMonthUserAccount(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByYearMonthUserAccount(deposit);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByUser(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByUser(deposit);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByAccount(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByAccount(deposit);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByStatus(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByStatus(deposit);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByUserStatus(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByUserStatus(deposit);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<DepositExtendDto> GetDepositsByAccountStatus(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            List<DepositExtendDto> deposits = depositRepository.GetDepositsByAccountStatus(deposit);

            if (deposits.Count != 0)
            {
                return deposits;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public DepositDto SaveDeposit(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IAccountRepository accountRepository = UnitOfWork.AccountRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (deposit == null || string.IsNullOrWhiteSpace(deposit.Amount.ToString().Trim()) || deposit.Year <= 0 || deposit.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            AccountExtendDto? accountSearch = accountRepository.GetAccountById(new AccountDto { IdAccount = deposit.IdAccount }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserExtendDto? userSearch = userRepository.GetUserById(new UserDto { IdUser = deposit.IdUser }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = deposit.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            List<DepositExtendDto>? depositSearch = depositRepository.GetDepositsByYearMonthUserAccount(deposit);

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

        public DepositDto UpdateDeposit(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();

            if (deposit == null || string.IsNullOrWhiteSpace(deposit.Amount.ToString().Trim()) || deposit.Year <= 0 || deposit.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            DepositExtendDto? depositSearch = depositRepository.GetDepositById(deposit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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

        public DepositDto DeleteDeposit(DepositDto deposit)
        {
            IDepositRepository depositRepository = UnitOfWork.DepositRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            DepositExtendDto? depositSearch = depositRepository.GetDepositById(deposit) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = deposit.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (depositSearch.IdStatus == deposit.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Deposit deleteDeposit = new()
            {
                IdDeposit = depositSearch.IdDeposit,
                Year = depositSearch.Year,
                Month = depositSearch.Month,
                Amount = depositSearch.Amount,
                IdUser = depositSearch.IdUser,
                IdAccount = depositSearch.IdAccount,
                IdStatus = statusSearch.IdStatus
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