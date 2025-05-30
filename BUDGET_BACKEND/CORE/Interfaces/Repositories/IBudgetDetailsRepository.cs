namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBudgetDetailsRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBudgetDetailsRepository
    {

        #region Métodos y Funciones

        public BudgetDetailExtendDto? GetBudgetDetailsById(int idBudgetDetails);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpense(int idExpense);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByStatus(int idStatus);

        public List<BudgetDetailExtendDto> GetBudgetDetailsByExpenseStatus(int idExpense, int idStatus);

        #endregion

    }
}