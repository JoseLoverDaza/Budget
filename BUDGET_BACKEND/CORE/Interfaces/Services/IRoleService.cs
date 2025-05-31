namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
   
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IRoleService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IRoleService
    {

        #region Métodos y Funciones

        public RoleExtendDto? GetRoleById(int idRole);

        public RoleExtendDto? GetRoleByName(string name);

        public List<RoleExtendDto> GetRolesByStatus(int idStatus);

        public RoleExtendDto SaveRole(RoleExtendDto role);

        public RoleExtendDto UpdateRole(RoleExtendDto role);

        public RoleExtendDto DeleteRole(RoleExtendDto role);

        #endregion 

    }
}