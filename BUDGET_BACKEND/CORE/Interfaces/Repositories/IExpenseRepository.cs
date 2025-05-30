namespace CORE.Interfaces.Repositories
{

    #region Using

    using CORE.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IExpenseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IExpenseRepository
    {

        #region Métodos y Funciones

        public ExpenseExtendDto? GetExpenseById(int id);

        public ExpenseExtendDto? GetExpenseByName(string name);

        public List<ExpenseExtendDto> GetExpensesByStatus(int status);

        #endregion Methods

    }
}