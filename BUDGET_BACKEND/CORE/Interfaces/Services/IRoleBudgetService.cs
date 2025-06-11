namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IRoleBudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IRoleBudgetService
    {

        #region Métodos y Funciones

        public RoleBudgetExtendDto? GetRoleBudgetByIdRoleBudget(RoleBudgetDto roleBudget);

        public RoleBudgetExtendDto? GetRoleBudgetByNameRole(RoleBudgetDto roleBudget);

        public List<RoleBudgetExtendDto> GetRolesBudgetByStatusBudget(RoleBudgetDto roleBudget);

        public RoleBudgetDto SaveRoleBudget(RoleBudgetDto roleBudget);

        public RoleBudgetDto UpdateRoleBudget(RoleBudgetDto roleBudget);

        public RoleBudgetDto DeleteRoleBudget(RoleBudgetDto roleBudget);

        #endregion 

    }
}