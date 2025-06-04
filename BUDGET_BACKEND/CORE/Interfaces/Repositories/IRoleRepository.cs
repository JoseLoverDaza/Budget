namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IRoleRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IRoleRepository
    {

        #region Métodos y Funciones

        public RoleExtendDto? GetRoleById(RoleDto role);

        public RoleExtendDto? GetRoleByName(RoleDto role);

        public List<RoleExtendDto> GetRolesByStatus(RoleDto role);

        #endregion 

    }
}