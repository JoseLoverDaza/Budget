namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBudgetRepository
    {

        #region Métodos y Funciones

        public BudgetExtendDto? GetBudgetById(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByYearMonth(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByYearUser(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByMonthUser(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByYearMonthUser(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByUser(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByStatus(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByUserStatus(BudgetDto budget);

        #endregion 

    }
}