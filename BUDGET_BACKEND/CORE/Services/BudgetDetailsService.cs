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
    using System.Net.NetworkInformation;
    using System.Runtime.InteropServices;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetDetailsService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetDetailsService : BaseService, IBudgetDetailsService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public BudgetDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public BudgetDetailExtendDto? GetBudgetDetailsById(int idBudgetDetails)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            BudgetDetailExtendDto? budgetDetails = budgetDetailRepository.GetBudgetDetailsById(idBudgetDetails);

            if (budgetDetails != null)
            {
                return budgetDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudget(int idBudget)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetails = budgetDetailRepository.GetBudgetDetailsByBudget(idBudget);

            if (budgetDetails.Count != 0)
            {
                return budgetDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(int idExpense)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetails = budgetDetailRepository.GetBudgetDetailsByExpense(idExpense);

            if (budgetDetails.Count != 0)
            {
                return budgetDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatus(int idStatus)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetails = budgetDetailRepository.GetBudgetDetailsByStatus(idStatus);

            if (budgetDetails.Count != 0)
            {
                return budgetDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpense(int idBudget, int idExpense)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetails = budgetDetailRepository.GetBudgetDetailsByBudgetExpense(idBudget, idExpense);

            if (budgetDetails.Count != 0)
            {
                return budgetDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatus(int idExpense, int idStatus)
        {
            IBudgetDetailsRepository budgetDetailRepository = UnitOfWork.BudgetDetailsRepository();
            List<BudgetDetailExtendDto> budgetDetails = budgetDetailRepository.GetBudgetDetailsByExpenseStatus(idExpense, idStatus);

            if (budgetDetails.Count != 0)
            {
                return budgetDetails;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }
        
        public BudgetDetailExtendDto SaveBudgetDetail(BudgetDetailExtendDto budgetDetail)
        {
            IBudgetDetailsRepository budgetDetailsRepository = UnitOfWork.BudgetDetailsRepository();
            IBudgetRepository budgetRepository = UnitOfWork.BudgetRepository();
            IExpenseRepository expenseRepository = UnitOfWork.ExpenseRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (budgetDetail == null || budgetDetail.Amount <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            List<BudgetDetailExtendDto> budgetDetailsSearch = budgetDetailsRepository.GetBudgetDetailsByBudgetExpense(budgetDetail.IdBudget, budgetDetail.IdExpense);

            if (budgetDetailsSearch.Count != 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BudgetExtendDto? budgetSearch = budgetRepository.GetBudgetById(budgetDetail.IdBudget) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            ExpenseExtendDto? expenseSearch = expenseRepository.GetExpenseById(budgetDetail.IdExpense) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(budgetDetail.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BudgetDetails saveBudgetDetails = new()
            {
                IdBudget = budgetSearch.IdBudget,
                CreationDate = budgetDetail.CreationDate,
                Amount = budgetDetail.Amount,
                IdExpense = expenseSearch.IdExpense,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BudgetDetails>().Add(saveBudgetDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            return budgetDetail;
        }

        public BudgetDetailExtendDto UpdateBudgetDetail(BudgetDetailExtendDto budgetDetail)
        {
            IBudgetDetailsRepository budgetDetailsRepository = UnitOfWork.BudgetDetailsRepository();

            if (budgetDetail == null || budgetDetail.IdBudget <= 0 || budgetDetail.IdExpense <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            BudgetDetailExtendDto? budgetDetailSearch = budgetDetailsRepository.GetBudgetDetailsById(budgetDetail.IdBudgetDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            BudgetDetails updateBudgetDetails = new()
            {
                IdBudgetDetails = budgetDetailSearch.IdBudgetDetails,
                IdBudget = budgetDetailSearch.IdBudget,
                CreationDate = budgetDetailSearch.CreationDate,
                Amount = budgetDetail.Amount,
                IdExpense = budgetDetailSearch.IdExpense,
                IdStatus = budgetDetailSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BudgetDetails>().Update(updateBudgetDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            return budgetDetail;
        }

        public BudgetDetailExtendDto DeleteBudgetDetail(BudgetDetailExtendDto budgetDetail)
        {
            IBudgetDetailsRepository budgetDetailsRepository = UnitOfWork.BudgetDetailsRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            BudgetDetailExtendDto? budgetDetailSearch = budgetDetailsRepository.GetBudgetDetailsById(budgetDetail.IdBudgetDetails) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(budgetDetail.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (statusSearch.IdStatus == budgetDetail.IdStatus)
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
                IdStatus = budgetDetailSearch.IdStatus
            };

            UnitOfWork.BaseRepository<BudgetDetails>().Update(deleteBudgetDetails);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return budgetDetail;
        }

        #endregion

    }
}