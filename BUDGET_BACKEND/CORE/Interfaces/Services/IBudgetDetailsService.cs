namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBudgetDetailsService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBudgetDetailsService
    {

        #region Métodos y Funciones

        public BudgetDetailExtendDto? GetBudgetDetailsById(int idBudgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(int idExpense);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatus(int idStatus);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatus(int idExpense, int idStatus);

        public BudgetDetailExtendDto SaveBudgetDetail(BudgetDetailExtendDto budgetDetail);

        public BudgetDetailExtendDto UpdateBudgetDetail(BudgetDetailExtendDto budgetDetail);

        public BudgetDetailExtendDto DeleteBudgetDetail(BudgetDetailExtendDto budgetDetail);

        #endregion

    }
}