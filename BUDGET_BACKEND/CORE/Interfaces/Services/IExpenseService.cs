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

        public ExpenseExtendDto? GetExpenseById(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByTypeExpense(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByStatus(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByNameTypeExpense(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByTypeExpenseStatus(ExpenseDto expense);

        public ExpenseExtendDto SaveExpense(ExpenseDto expense);

        public ExpenseExtendDto UpdateExpense(ExpenseDto expense);

        public ExpenseExtendDto DeleteExpense(ExpenseDto expense);


        #endregion

    }
}