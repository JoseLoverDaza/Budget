namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IRoleService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IRoleService
    {

        #region Métodos y Funciones

        public RoleExtendDto? GetRoleById(RoleDto role);

        public RoleExtendDto? GetRoleByName(RoleDto role);

        public List<RoleExtendDto> GetRolesByStatus(RoleDto role);

        public RoleExtendDto SaveRole(RoleDto role);

        public RoleExtendDto UpdateRole(RoleDto role);

        public RoleExtendDto DeleteRole(RoleDto role);

        #endregion 

    }
}