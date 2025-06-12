namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBudgetDetailsService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBudgetDetailsService
    {

        #region Métodos y Funciones

        public BudgetDetailExtendDto? GetBudgetDetailsByIdBudgetDetails(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudget(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatusBudget(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpense(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatusBudget(BudgetDetailsDto budgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByBudgetExpenseStatusBudget(BudgetDetailsDto budgetDetails);

        public BudgetDetailsDto SaveBudgetDetail(BudgetDetailsDto budgetDetails);

        public BudgetDetailsDto UpdateBudgetDetail(BudgetDetailsDto budgetDetails);

        public BudgetDetailsDto DeleteBudgetDetail(BudgetDetailsDto budgetDetails);

        #endregion

    }
}