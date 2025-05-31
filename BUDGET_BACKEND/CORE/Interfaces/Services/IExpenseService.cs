namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IExpenseService
    {

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseById(int idExpense);

        public ExpenseExtendDto? GetExpenseByName(string name);

        public List<ExpenseExtendDto> GetExpensesByStatus(int idStatus);

        public ExpenseExtendDto SaveExpense(ExpenseExtendDto expense);

        public ExpenseExtendDto UpdateExpense(ExpenseExtendDto expense);

        public ExpenseExtendDto DeleteExpense(ExpenseExtendDto expense);


        #endregion

    }
}