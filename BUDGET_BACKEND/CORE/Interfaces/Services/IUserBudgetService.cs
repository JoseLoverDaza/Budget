namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IUserBudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IUserBudgetService
    {

        #region Métodos y Funciones

        public UserBudgetExtendDto? GetUserBudgetByIdUserBudget(UserBudgetDto userBudget);

        public UserBudgetExtendDto? GetUserBudgetByEmail(UserBudgetDto userBudget);

        public UserBudgetExtendDto? GetUserBudgetByUsername(UserBudgetDto userBudget);

        public List<UserBudgetExtendDto> GetUsersBudgetByRoleBudget(UserBudgetDto userBudget);

        public List<UserBudgetExtendDto> GetUsersBudgetByStatusBudget(UserBudgetDto userBudget);

        public List<UserBudgetExtendDto> GetUsersBudgetByRoleBudgetStatusBudget(UserBudgetDto userBudget);

        public UserBudgetDto SaveUserBudget(UserBudgetDto userBudget);

        public UserBudgetDto UpdateUserBudget(UserBudgetDto userBudget);

        public UserBudgetDto DeleteUserBudget(UserBudgetDto userBudget);

        #endregion

    }
}