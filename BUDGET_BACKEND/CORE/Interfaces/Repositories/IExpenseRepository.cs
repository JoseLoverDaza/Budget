namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IExpenseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IExpenseRepository
    {

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseById(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByTypeExpense(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByStatus(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByNameTypeExpense(ExpenseDto expense);

        public List<ExpenseExtendDto> GetExpensesByTypeExpenseStatus(ExpenseDto expense);

        #endregion

    }
}