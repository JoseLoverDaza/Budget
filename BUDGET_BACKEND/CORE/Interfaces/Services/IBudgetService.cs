namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBudgetService
    {

        #region Métodos y Funciones

        public BudgetExtendDto? GetBudgetByIdBudget(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByYearMonth(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByYearUserBudget(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByMonthUserBudget(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByYearMonthUserBudget(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByUserBudget(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByStatusBudget(BudgetDto budget);

        public List<BudgetExtendDto> GetBudgetsByUserBudgetStatusBudget(BudgetDto budget);

        public BudgetDto SaveBudget(BudgetDto budget);

        public BudgetDto UpdateBudget(BudgetDto budget);

        public BudgetDto DeleteBudget(BudgetDto budget);

        #endregion 

    }
}