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
    /// Nombre: BillingService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingService : BaseService, IBillingService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public BillingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {             
        }

        #endregion

        #region Métodos y Funciones

        public BillingExtendDto? GetBillingById(int idBilling)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            BillingExtendDto? billing = billingRepository.GetBillingById(idBilling);

            if (billing != null)
            {
                return billing;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BillingExtendDto? GetBillingByYearMonthUser(int year, int month, int idUser)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            BillingExtendDto? billing = billingRepository.GetBillingByYearMonthUser(year, month, idUser);

            if (billing != null)
            {
                return billing;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByStatus(int idStatus)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByStatus(idStatus);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByUser(int idUser)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByUser(idUser);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingExtendDto> GetBillingsByUserStatus(int idUser, int idStatus)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            List<BillingExtendDto> billings = billingRepository.GetBillingsByUserStatus(idUser, idStatus);

            if (billings.Count != 0)
            {
                return billings;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BillingExtendDto SaveBilling(BillingExtendDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            IUserRepository userRepository = UnitOfWork.UserRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (billing == null || billing.Year <= 0 || billing.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            UserExtendDto? userSearch = userRepository.GetUserById(billing.IdUser) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(billing.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BillingExtendDto? billingSearch = billingRepository.GetBillingByYearMonthUser(billing.Year, billing.Month, billing.IdUser);

            if (billingSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Billing saveBilling = new()
            {
                Year = billing.Year,
                Month = billing.Month,
                CreationDate = billing.CreationDate,
                Description = billing.Description,
                Observation = billing.Observation,
                IdUser = userSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Billing>().Add(saveBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return billing;
        }

        public BillingExtendDto UpdateBilling(BillingExtendDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();

            if (billing == null || billing.Year <= 0 || billing.Month <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingExtendDto? billingSearch = billingRepository.GetBillingById(billing.IdBilling) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Billing updateBilling = new()
            {
                IdBilling = billingSearch.IdBilling,
                Year = billingSearch.Year,
                Month = billingSearch.Month,
                CreationDate = billing.CreationDate,
                Description = billing.Description,
                Observation = billing.Observation,
                IdUser = billingSearch.IdUser,
                IdStatus = billingSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Billing>().Update(updateBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return billing;
        }

        public BillingExtendDto DeleteBilling(BillingExtendDto billing)
        {
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            BillingExtendDto? billingSearch = billingRepository.GetBillingById(billing.IdBilling) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(billing.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusSearch.IdStatus == billing.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Billing deleteBilling = new()
            {
                IdBilling = billingSearch.IdBilling,
                Year = billingSearch.Year,
                Month = billingSearch.Month,
                CreationDate = billingSearch.CreationDate,
                Description = billingSearch.Description,
                Observation = billingSearch.Observation,
                IdUser = billingSearch.IdUser,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Billing>().Update(deleteBilling);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            return billing;
        }

        #endregion
    }
}