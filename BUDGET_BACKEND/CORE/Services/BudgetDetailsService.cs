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
    /// Nombre: BudgetDetailsService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetDetailsService : BaseService, IBudgetDetailsService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public BudgetDetailsService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public BudgetDetailExtendDto? GetBudgetDetailsById(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            BudgetDetailExtendDto? budgetDetailsSearch = budgetDetailRepository.GetBudgetDetailsByIdBudgetDetails(budgetDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgetDetailsSearch != null)
            {
                return budgetDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudget(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetailsSearch = budgetDetailRepository.GetBudgetDetailsByBudget(budgetDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgetDetailsSearch.Count != 0)
            {
                return budgetDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetailsSearch = budgetDetailRepository.GetBudgetDetailsByExpense(budgetDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgetDetailsSearch.Count != 0)
            {
                return budgetDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatus(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetailsSearch = budgetDetailRepository.GetBudgetDetailsByStatusBudget(budgetDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgetDetailsSearch.Count != 0)
            {
                return budgetDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpense(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetailsSearch = budgetDetailRepository.GetBudgetDetailsByBudgetExpense(budgetDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgetDetailsSearch.Count != 0)
            {
                return budgetDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatus(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetailsSearch = budgetDetailRepository.GetBudgetDetailsByExpenseStatusBudget(budgetDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgetDetailsSearch.Count != 0)
            {
                return budgetDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpenseStatus(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetailsSearch = budgetDetailRepository.GetBudgetDetailsByBudgetExpenseStatusBudget(budgetDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (budgetDetailsSearch.Count != 0)
            {
                return budgetDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BudgetDetailsDto SaveBudgetDetail(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailsRepository = UnitOfWork.BudgetDetailsRepository();
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            if (budgetDetails == null || budgetDetails.Amount <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<BudgetDetailExtendDto> budgetDetailsSearch = budgetDetailsRepository.GetBudgetDetailsByBudgetExpense(budgetDetails);

            if (budgetDetailsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetByIdBudget(new BudgetDto { IdBudget = budgetDetails.IdBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseByIdExpense(new ExpenseDto { IdExpense = budgetDetails.IdExpense }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = budgetDetails.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BudgetDetails saveBudgetDetails = new()
            {
                IdBudget = budgetSearch.IdBudget,
                CreationDate = budgetDetails.CreationDate,
                Amount = budgetDetails.Amount,
                IdExpense = expenseSearch.IdExpense,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BudgetDetails>().Add(saveBudgetDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(BudgetDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveBudgetDetails), DateTime.Now, null);

            return budgetDetails;
        }

        public BudgetDetailsDto UpdateBudgetDetail(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailsRepository = UnitOfWork.BudgetDetailsRepository();

            if (budgetDetails == null || budgetDetails.IdBudget <= 0 || budgetDetails.IdExpense <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BudgetDetailExtendDto? budgetDetailSearch = budgetDetailsRepository.GetBudgetDetailsByIdBudgetDetails(budgetDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BudgetDetails updateBudgetDetails = new()
            {
                IdBudgetDetails = budgetDetailSearch.IdBudgetDetails,
                IdBudget = budgetDetailSearch.IdBudget,
                CreationDate = budgetDetailSearch.CreationDate,
                Amount = budgetDetails.Amount,
                IdExpense = budgetDetailSearch.IdExpense,
                IdStatus = budgetDetailSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BudgetDetails>().Update(updateBudgetDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(BudgetDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(budgetDetailSearch), JsonSerializer.Serialize(updateBudgetDetails), DateTime.Now, null);

            return budgetDetails;
        }

        public BudgetDetailsDto DeleteBudgetDetail(BudgetDetailsDto budgetDetails)
        {
            IBudgetDetailsRepository budgetDetailsRepository = UnitOfWork.BudgetDetailsRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            BudgetDetailExtendDto? budgetDetailSearch = budgetDetailsRepository.GetBudgetDetailsByIdBudgetDetails(budgetDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = budgetDetails.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (budgetDetailSearch.IdStatus == budgetDetails.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BudgetDetails deleteBudgetDetails = new()
            {
                IdBudgetDetails = budgetDetailSearch.IdBudgetDetails,
                IdBudget = budgetDetailSearch.IdBudget,
                CreationDate = budgetDetailSearch.CreationDate,
                Amount = budgetDetailSearch.Amount,
                IdExpense = budgetDetailSearch.IdExpense,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BudgetDetails>().Update(deleteBudgetDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(BudgetDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(budgetDetailSearch), JsonSerializer.Serialize(deleteBudgetDetails), DateTime.Now, null);

            return budgetDetails;
        }

        #endregion

    }
}