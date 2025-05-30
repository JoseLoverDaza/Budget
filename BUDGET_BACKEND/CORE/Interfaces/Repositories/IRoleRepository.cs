namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IRoleRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IRoleRepository
    {

        #region Métodos y Funciones

        public RoleExtendDto? GetRoleById(int idRole);

        public RoleExtendDto? GetRoleByName(string name);

        public List<RoleExtendDto> GetRolesByStatus(int idStatus);

        #endregion 

    }
}