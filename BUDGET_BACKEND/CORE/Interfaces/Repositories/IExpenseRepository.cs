namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IExpenseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IExpenseRepository
    {

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseById(int idExpense);

        public ExpenseExtendDto? GetExpenseByName(string name);

        public List<ExpenseExtendDto> GetExpensesByTypeExpense(int idTypeExpense);

        public List<ExpenseExtendDto> GetExpensesByStatus(int idStatus);

        public List<ExpenseExtendDto> GetExpensesByTypeExpenseStatus(int idTypeExpense, int idStatus);

        #endregion

    }
}