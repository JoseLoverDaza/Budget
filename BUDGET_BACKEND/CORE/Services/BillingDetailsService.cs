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
    /// Nombre: BillingDetailsService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingDetailsService : BaseService, IBillingDetailsService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public BillingDetailsService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public BillingDetailExtendDto? GetBillingDetailsById(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            BillingDetailExtendDto? billingDetailsSearch = billingDetailRepository.GetBillingDetailsByIdBillingDetails(billingDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billingDetailsSearch != null)
            {
                return billingDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByBilling(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByBilling(billingDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billingDetailsSearch.Count != 0)
            {
                return billingDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByExpense(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByExpense(billingDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billingDetailsSearch.Count != 0)
            {
                return billingDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByStatus(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByStatusBudget(billingDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billingDetailsSearch.Count != 0)
            {
                return billingDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpense(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByBillingExpense(billingDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billingDetailsSearch.Count != 0)
            {
                return billingDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByExpenseStatus(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByExpenseStatusBudget(billingDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billingDetailsSearch.Count != 0)
            {
                return billingDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpenseStatus(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByBillingExpenseStatusBudget(billingDetails);

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billingDetailsSearch.Count != 0)
            {
                return billingDetailsSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BillingDetailsDto SaveBillingDetail(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            if (billingDetails == null || billingDetails.Amount <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByBillingExpense(billingDetails);

            if (billingDetailsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingExtendDto? billingSearch = billingRepository.GetBillingByIdBilling(new BillingDto { IdBilling = billingDetails.IdBilling }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseByIdExpense(new ExpenseDto { IdExpense = billingDetails.IdExpense }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = billingDetails.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BillingDetails saveBillingDetails = new()
            {
                IdBilling = billingSearch.IdBilling,
                CreationDate = billingDetails.CreationDate,
                Amount = billingDetails.Amount,
                IdExpense = expenseSearch.IdExpense,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BillingDetails>().Add(saveBillingDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveBillingDetails), DateTime.Now, null);

            return billingDetails;
        }

        public BillingDetailsDto UpdateBillingDetail(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();

            if (billingDetails == null || billingDetails.IdBilling <= 0 || billingDetails.IdExpense <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingDetailExtendDto? billingDetailSearch = billingDetailRepository.GetBillingDetailsByIdBillingDetails(billingDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BillingDetails updateBillingDetails = new()
            {
                IdBillingDetails = billingDetailSearch.IdBillingDetails,
                IdBilling = billingDetailSearch.IdBilling,
                CreationDate = billingDetailSearch.CreationDate,
                Amount = billingDetails.Amount,
                IdExpense = billingDetailSearch.IdExpense,
                IdStatus = billingDetailSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BillingDetails>().Update(updateBillingDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(BillingDetails).Name, Constants.Method.POST, JsonSerializer.Serialize(billingDetailSearch), JsonSerializer.Serialize(updateBillingDetails), DateTime.Now, null);

            return billingDetails;
        }

        public BillingDetailsDto DeleteBillingDetail(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            IStatusBudgetRepository statusRepository = UnitOfWork.StatusRepository();

            BillingDetailExtendDto? billingDetailSearch = billingDetailRepository.GetBillingDetailsByIdBillingDetails(billingDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = billingDetails.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (billingDetailSearch.IdStatus == billingDetails.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingDetails deleteBillingDetails = new()
            {
                IdBillingDetails = billingDetailSearch.IdBillingDetails,
                IdBilling = billingDetailSearch.IdBilling,
                CreationDate = billingDetailSearch.CreationDate,
                Amount = billingDetailSearch.Amount,
                IdExpense = billingDetailSearch.IdExpense,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BillingDetails>().Update(deleteBillingDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Audit).Name, Constants.Method.POST, JsonSerializer.Serialize(billingDetailSearch), JsonSerializer.Serialize(deleteBillingDetails), DateTime.Now, null);

            return billingDetails;
        }

        #endregion Constructor

    }
}