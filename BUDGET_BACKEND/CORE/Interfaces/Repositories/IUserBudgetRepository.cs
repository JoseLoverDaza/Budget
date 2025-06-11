namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IUserBudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IUserBudgetRepository
    {

        #region Métodos y Funciones

        public UserBudgetExtendDto? GetUserBudgetByIdUserBudget(UserBudgetDto userBudget);

        public UserBudgetExtendDto? GetUserBudgetByEmail(UserBudgetDto userBudget);

        public UserBudgetExtendDto? GetUserBudgetByUsername(UserBudgetDto userBudget);

        public List<UserBudgetExtendDto> GetUsersBudgetByRoleBudget(UserBudgetDto userBudget);

        public List<UserBudgetExtendDto> GetUsersBudgetByStatusBudget(UserBudgetDto userBudget);

        public List<UserBudgetExtendDto> GetUsersBudgetByRoleBudgetStatusBudget(UserBudgetDto userBudget);

        #endregion

    }
}