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
    using System.Security.Principal;
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingService : BaseService, IBillingService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public BillingService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public BillingExtendDto? GetBillingByIdBilling(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            BillingExtendDto? billingSearch = billingRepository.GetBillingByIdBilling(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(billing), DateTime.Now, null);

            if (billingSearch != null)
            {
                return billingSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByYearMonth(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByYearMonth(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(billing), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByYearUserBudget(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByYearUserBudget(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(billing), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByMonthUserBudget(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByMonthUserBudget(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(billing), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByYearMonthUserBudget(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByYearMonthUserBudget(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(billing), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByUserBudget(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByUserBudget(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(billing), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByStatusBudget(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByStatusBudget(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(billing), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByUserBudgetStatusBudget(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByUserBudgetStatusBudget(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.CONSULT, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), Json.SerializeWithoutNulls(billing), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BillingDto SaveBilling(BillingDto billing)
        {
            IUserBudgetRepository userBudgetRepository = UnitOfWork.UserBudgetRepository();
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();         
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            if (billing == null || billing.YearBilling <= 0 || billing.MonthBilling <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserBudgetExtendDto? userBudgetAdminSearch = userBudgetRepository.GetUserBudgetByUsername(new UserBudgetDto { Username = Constants.UserBudget.USERNAME_ADMIN }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            UserBudgetExtendDto? userBudgetSearch = userBudgetRepository.GetUserBudgetByIdUserBudget(new UserBudgetDto { IdUserBudget = billing.IdUserBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = billing.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            List<BillingExtendDto> billingsSearch = billingRepository.GetBillingsByYearMonthUserBudget(billing);

            if (billingsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Billing saveBilling = new()
            {
                YearBilling = billing.YearBilling,
                MonthBilling = billing.MonthBilling,              
                DescriptionBilling = billing.DescriptionBilling?.Trim() ?? string.Empty,
                ObservationBilling = billing.ObservationBilling?.Trim() ?? string.Empty,
                IdUserBudget = userBudgetSearch.IdUserBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = userBudgetAdminSearch.IdUserBudget,
                CreationDate = billing.CreationDate,
                ModificationUser = userBudgetAdminSearch.IdUserBudget,
                ModificationDate = billing.ModificationDate
            };

            UnitOfWork.BaseRepository<Billing>().Add(saveBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.SAVE, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveBilling), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return billing;
        }

        public BillingDto UpdateBilling(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();

            if (billing == null || billing.YearBilling <= 0 || billing.MonthBilling <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingExtendDto? billingSearch = billingRepository.GetBillingByIdBilling(billing) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Billing updateBilling = new()
            {
                IdBilling = billingSearch.IdBilling,
                YearBilling = billingSearch.YearBilling,
                MonthBilling = billingSearch.MonthBilling,               
                DescriptionBilling = billing.DescriptionBilling?.Trim() ?? string.Empty,
                ObservationBilling = billing.ObservationBilling?.Trim() ?? string.Empty,
                IdUserBudget = billingSearch.IdUserBudget,
                IdStatusBudget = billingSearch.IdStatusBudget,
                CreationUser = billingSearch.CreationUser,
                CreationDate = billingSearch.CreationDate,
                ModificationUser = billingSearch.ModificationUser,
                ModificationDate = billing.ModificationDate
            };

            UnitOfWork.BaseRepository<Billing>().Update(updateBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.UPDATE, JsonSerializer.Serialize(billingSearch), JsonSerializer.Serialize(updateBilling), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return billing;
        }

        public BillingDto DeleteBilling(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            IStatusBudgetRepository statusBudgetRepository = UnitOfWork.StatusBudgetRepository();

            BillingExtendDto? billingSearch = billingRepository.GetBillingByIdBilling(billing) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusBudgetDto? statusBudgetSearch = statusBudgetRepository.GetStatusBudgetByIdStatusBudget(new StatusBudgetDto { IdStatusBudget = billing.IdStatusBudget }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (billingSearch.IdStatusBudget == billing.IdStatusBudget)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Billing deleteBilling = new()
            {
                IdBilling = billingSearch.IdBilling,
                YearBilling = billingSearch.YearBilling,
                MonthBilling = billingSearch.MonthBilling,                
                DescriptionBilling = billingSearch.DescriptionBilling?.Trim() ?? string.Empty,
                ObservationBilling = billingSearch.ObservationBilling?.Trim() ?? string.Empty,
                IdUserBudget = billingSearch.IdUserBudget,
                IdStatusBudget = statusBudgetSearch.IdStatusBudget,
                CreationUser = billingSearch.CreationUser,
                CreationDate = billingSearch.CreationDate,
                ModificationUser = billingSearch.ModificationUser,
                ModificationDate = billing.ModificationDate
            };

            UnitOfWork.BaseRepository<Billing>().Update(deleteBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Billing).Name, Constants.EntityAction.DELETE, JsonSerializer.Serialize(billingSearch), JsonSerializer.Serialize(deleteBilling), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            return billing;
        }

        #endregion
    }
}