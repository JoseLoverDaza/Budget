namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBudgetDetailsRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBudgetDetailsRepository
    {

        #region Métodos y Funciones

        public BudgetDetailExtendDto? GetBudgetDetailsById(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudget(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatus(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpense(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatus(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpenseStatus(BudgetDetailsDto budgetDetails);

        #endregion

    }
}