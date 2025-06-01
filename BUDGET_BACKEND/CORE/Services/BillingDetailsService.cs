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

        public BillingDetailExtendDto? GetBillingDetailsById(int idBillingDetails)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            BillingDetailExtendDto? billingDetails = billingDetailRepository.GetBillingDetailsById(idBillingDetails);

            if (billingDetails != null)
            {
                return billingDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByBilling(int idBilling)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetails = billingDetailRepository.GetBillingDetailsByBilling(idBilling);

            if (billingDetails.Count != 0)
            {
                return billingDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByExpense(int idExpense)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetails = billingDetailRepository.GetBillingDetailsByExpense(idExpense);

            if (billingDetails.Count != 0)
            {
                return billingDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpense(int idBilling, int idExpense)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetails = billingDetailRepository.GetBillingDetailsByBillingExpense(idBilling, idExpense);

            if (billingDetails.Count != 0)
            {
                return billingDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByExpenseStatus(int idExpense, int idStatus)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetails = billingDetailRepository.GetBillingDetailsByExpenseStatus(idExpense, idStatus);

            if (billingDetails.Count != 0)
            {
                return billingDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByStatus(int idStatus)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            List<BillingDetailExtendDto> billingDetails = billingDetailRepository.GetBillingDetailsByStatus(idStatus);

            if (billingDetails.Count != 0)
            {
                return billingDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public BillingDetailExtendDto SaveBillingDetail(BillingDetailExtendDto billingDetail)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            IBillingRepository billingRepository = UnitOfWork.BillingRepository();
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (billingDetail == null || billingDetail.Amount <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<BillingDetailExtendDto> billingDetailsSearch = billingDetailRepository.GetBillingDetailsByBillingExpense(billingDetail.IdBilling, billingDetail.IdExpense);

            if (billingDetailsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingExtendDto? billingSearch = billingRepository.GetBillingById(billingDetail.IdBilling) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseById(billingDetail.IdExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(billingDetail.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BillingDetails saveBillingDetails = new()
            {
                IdBilling = billingSearch.IdBilling,
                CreationDate = billingDetail.CreationDate,
                Amount = billingDetail.Amount,
                IdExpense = expenseSearch.IdExpense,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BillingDetails>().Add(saveBillingDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            return billingDetail;
        }

        public BillingDetailExtendDto UpdateBillingDetail(BillingDetailExtendDto billingDetail)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();

            if (billingDetail == null || billingDetail.IdBilling <= 0 || billingDetail.IdExpense <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BillingDetailExtendDto? billingDetailSearch = billingDetailRepository.GetBillingDetailsById(billingDetail.IdBillingDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BillingDetails updateBillingDetails = new()
            {
                IdBillingDetails = billingDetail.IdBillingDetails,
                IdBilling = billingDetailSearch.IdBilling,
                CreationDate = billingDetailSearch.CreationDate,
                Amount = billingDetail.Amount,
                IdExpense = billingDetailSearch.IdExpense,
                IdStatus = billingDetailSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BillingDetails>().Update(updateBillingDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            return billingDetail;
        }

        public BillingDetailExtendDto DeleteBillingDetail(BillingDetailExtendDto billingDetail)
        {
            IBillingDetailsRepository billingDetailRepository = UnitOfWork.BillingDetailsRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            BillingDetailExtendDto? billingDetailSearch = billingDetailRepository.GetBillingDetailsById(billingDetail.IdBillingDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(billingDetail.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusSearch.IdStatus == billingDetail.IdStatus)
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
                IdStatus = billingDetail.IdStatus
            };

            UnitOfWork.BaseRepository<BillingDetails>().Update(deleteBillingDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return billingDetail;
        }

        #endregion Constructor

    }
}