namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IExpenseService
    {

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseByIdExpense(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByTypeExpense(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByStatusBudget(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByNameTypeExpense(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByTypeExpenseStatusBudget(ExpenseDto expense);

        public ExpenseDto SaveExpense(ExpenseDto expense);

        public ExpenseDto UpdateExpense(ExpenseDto expense);

        public ExpenseDto DeleteExpense(ExpenseDto expense);

        #endregion

    }
}