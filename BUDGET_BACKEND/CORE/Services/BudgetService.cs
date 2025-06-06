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
    /// Nombre: BudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetService : BaseService, IBudgetService
    {

        #region #region Atributos y Propiedades

        #endregion

        #region Constructor

        public BudgetService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {            
        }

        #endregion

        #region Métodos y Funciones

        public BudgetExtendDto? GetBudgetById(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetById(budget);

            if (budgetSearch != null)
            {
                return budgetSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByYearMonth(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByYearMonth(budget);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByYearUser(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByYearUser(budget);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByMonthUser(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByMonthUser(budget);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByYearMonthUser(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByYearMonthUser(budget);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByUser(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByUser(budget);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByStatus(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByStatus(budget);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByUserStatus(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByUserStatus(budget);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BudgetDto SaveBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (budget == null || budget.Year <= 0 || budget.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userSearch = userRepository.GetUserById(new UserDto { IdUser = budget.IdUser} ) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = budget.IdStatus} ) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            List<BudgetExtendDto> budgetsSearch = budgetRepository.GetBudgetsByYearMonthUser(budget);

            if (budgetsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Budget saveBudget = new()
            {
                Year = budget.Year,
                Month = budget.Month,
                CreationDate = budget.CreationDate,
                Description = budget.Description?.Trim() ?? string.Empty,
                Observation = budget.Observation?.Trim() ?? string.Empty,
                IdUser = userSearch.IdUser,               
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Budget>().Add(saveBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return budget;
        }

        public BudgetDto UpdateBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();

            if(budget == null || budget.Year <= 0 || budget.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetById(budget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Budget updateBudget = new()
            {
                IdBudget = budgetSearch.IdBudget,
                Year = budgetSearch.Year,
                Month = budgetSearch.Month,
                CreationDate = budget.CreationDate,
                Description = budget.Description?.Trim() ?? string.Empty,
                Observation = budget.Observation?.Trim() ?? string.Empty,
                IdUser = budgetSearch.IdUser,
                IdStatus = budgetSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Budget>().Update(updateBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return budget;
        }

        public BudgetDto DeleteBudget(BudgetDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetById(budget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = budget.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (budgetSearch.IdStatus == budget.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Budget deleteBudget = new()
            {
                IdBudget = budgetSearch.IdBudget,
                Year = budgetSearch.Year,
                Month = budgetSearch.Month,
                CreationDate = budgetSearch.CreationDate,
                Description = budgetSearch.Description?.Trim() ?? string.Empty,
                Observation = budgetSearch.Observation?.Trim() ?? string.Empty,
                IdUser = budgetSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Budget>().Update(deleteBudget);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            return budget;
        }

        #endregion Constructor

    }
}