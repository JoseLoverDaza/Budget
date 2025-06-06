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
    /// Nombre: BillingDetailsService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingDetailsService : BaseService, IBillingDetailsService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public BillingDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {            
        }

        #endregion

        #region Métodos y Funciones

        public BillingDetailExtendDto? GetBillingDetailsById(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            BillingDetailExtendDto? billingDetailsSearch = billingDetailRepository.GetBillingDetailsById(billingDetails);

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
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByStatus(billingDetails);

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
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByExpenseStatus(billingDetails);

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
            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByBillingExpenseStatus(billingDetails);

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
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (billingDetails == null || billingDetails.Amount <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByBillingExpense(billingDetails);

            if (billingDetailsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingExtendDto? billingSearch = billingRepository.GetBillingById(new BillingDto { IdBilling = billingDetails.IdBilling }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseById(new ExpenseDto { IdExpense = billingDetails.IdExpense }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
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

            return billingDetails;
        }

        public BillingDetailsDto UpdateBillingDetail(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();

            if (billingDetails == null || billingDetails.IdBilling <= 0 || billingDetails.IdExpense <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingDetailExtendDto? billingDetailSearch = billingDetailRepository.GetBillingDetailsById(billingDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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

            return billingDetails;
        }

        public BillingDetailsDto DeleteBillingDetail(BillingDetailsDto billingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            BillingDetailExtendDto? billingDetailSearch = billingDetailRepository.GetBillingDetailsById(billingDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById( new StatusDto { IdStatus = billingDetails.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

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
            return billingDetails;
        }

        #endregion Constructor

    }
}