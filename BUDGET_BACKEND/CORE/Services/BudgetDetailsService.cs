namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(int idExpense)
        {
            throw new NotImplementedException();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatus(int idExpense, int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public BudgetDetailExtendDto SaveBudgetDetail(BudgetDetailExtendDto budgetDetail)
        {
            throw new NotImplementedException();
        }

        public BudgetDetailExtendDto UpdateBudgetDetail(BudgetDetailExtendDto budgetDetail)
        {
            throw new NotImplementedException();
        }

        public BudgetDetailExtendDto DeleteBudgetDetail(BudgetDetailExtendDto budgetDetail)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}