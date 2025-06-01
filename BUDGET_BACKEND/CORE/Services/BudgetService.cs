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

        public BudgetExtendDto? GetBudgetById(int idBudget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            BudgetExtendDto? budget = budgetRepository.GetBudgetById(idBudget);

            if (budget != null)
            {
                return budget;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BudgetExtendDto? GetBudgetByYearMonthUser(int year, int month, int idUser)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            BudgetExtendDto? budget = budgetRepository.GetBudgetByYearMonthUser(year, month, idUser);

            if (budget != null)
            {
                return budget;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByStatus(int idStatus)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByStatus(idStatus);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByUser(int idUser)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByUser(idUser);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetExtendDto> GetBudgetsByUserStatus(int idUser, int idStatus)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            List<BudgetExtendDto> budgets = budgetRepository.GetBudgetsByUserStatus(idUser, idStatus);

            if (budgets.Count != 0)
            {
                return budgets;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BudgetExtendDto SaveBudget(BudgetExtendDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            IUserRepository userRepository = UnitOfWork.UserRepository();           
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (budget == null || budget.Year <= 0 || budget.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
                        
            UserExtendDto? userSearch = userRepository.GetUserById(budget.IdUser) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(budget.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetByYearMonthUser(budget.Year, budget.Month, budget.IdUser);

            if (budgetSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Budget saveBudget = new()
            {
                Year = budget.Year,
                Month = budget.Month,
                CreationDate = budget.CreationDate,
                Description = budget.Description,
                Observation = budget.Observation,
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

        public BudgetExtendDto UpdateBudget(BudgetExtendDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();

            if(budget == null || budget.Year <= 0 || budget.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetById(budget.IdBudget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Budget updateBudget = new()
            {
                IdBudget = budgetSearch.IdBudget,
                Year = budgetSearch.Year,
                Month = budgetSearch.Month,
                CreationDate = budget.CreationDate,
                Description = budget.Description,
                Observation = budget.Observation,
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

        public BudgetExtendDto DeleteBudget(BudgetExtendDto budget)
        {
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetById(budget.IdBudget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(budget.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusSearch.IdStatus == budget.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Budget deleteBudget = new()
            {
                IdBudget = budgetSearch.IdBudget,
                Year = budgetSearch.Year,
                Month = budgetSearch.Month,
                CreationDate = budgetSearch.CreationDate,
                Description = budgetSearch.Description,
                Observation = budgetSearch.Observation,
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