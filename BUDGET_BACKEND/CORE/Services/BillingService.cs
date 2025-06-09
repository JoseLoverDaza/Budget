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

        public BillingExtendDto? GetBillingById(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            BillingExtendDto? billingSearch = billingRepository.GetBillingById(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByYearUser(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByYearUser(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByMonthUser(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByMonthUser(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByYearMonthUser(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByYearMonthUser(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByUser(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByUser(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByStatus(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByStatus(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByUserStatus(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByUserStatus(billing);

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

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
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (billing == null || billing.Year <= 0 || billing.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userSearch = userRepository.GetUserById(new UserDto { IdUser = billing.IdUser }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = billing.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            List<BillingExtendDto> billingsSearch = billingRepository.GetBillingsByYearMonthUser(billing);

            if (billingsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Billing saveBilling = new()
            {
                Year = billing.Year,
                Month = billing.Month,
                CreationDate = billing.CreationDate,
                Description = billing.Description?.Trim() ?? string.Empty,
                Observation = billing.Observation?.Trim() ?? string.Empty,
                IdUser = userSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Billing>().Add(saveBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveBilling), DateTime.Now, null);

            return billing;
        }

        public BillingDto UpdateBilling(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();

            if (billing == null || billing.Year <= 0 || billing.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingExtendDto? billingSearch = billingRepository.GetBillingById(billing) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Billing updateBilling = new()
            {
                IdBilling = billingSearch.IdBilling,
                Year = billingSearch.Year,
                Month = billingSearch.Month,
                CreationDate = billing.CreationDate,
                Description = billing.Description?.Trim() ?? string.Empty,
                Observation = billing.Observation?.Trim() ?? string.Empty,
                IdUser = billingSearch.IdUser,
                IdStatus = billingSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Billing>().Update(updateBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(billingSearch), JsonSerializer.Serialize(updateBilling), DateTime.Now, null);

            return billing;
        }

        public BillingDto DeleteBilling(BillingDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            BillingExtendDto? billingSearch = billingRepository.GetBillingById(billing) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = billing.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (billingSearch.IdStatus == billing.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Billing deleteBilling = new()
            {
                IdBilling = billingSearch.IdBilling,
                Year = billingSearch.Year,
                Month = billingSearch.Month,
                CreationDate = billingSearch.CreationDate,
                Description = billingSearch.Description?.Trim() ?? string.Empty,
                Observation = billingSearch.Observation?.Trim() ?? string.Empty,
                IdUser = billingSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Billing>().Update(deleteBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Billing).Name, Constants.Method.POST, JsonSerializer.Serialize(billingSearch), JsonSerializer.Serialize(deleteBilling), DateTime.Now, null);

            return billing;
        }

        #endregion
    }
}