namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IRoleBudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IRoleBudgetRepository
    {

        #region Métodos y Funciones

        public RoleBudgetExtendDto? GetRoleBudgetByIdRoleBudget(RoleBudgetDto roleBudget);

        public RoleBudgetExtendDto? GetRoleBudgetByNameRole(RoleBudgetDto roleBudget);

        public List<RoleBudgetExtendDto> GetRolesBudgetByStatusBudget(RoleBudgetDto roleBudget);

        #endregion 

    }
}