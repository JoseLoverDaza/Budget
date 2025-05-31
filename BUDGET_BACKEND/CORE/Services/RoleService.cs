namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class RoleService : BaseService, IRoleService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public RoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones
        
        public RoleExtendDto? GetRoleById(int idRole)
        {
            throw new NotImplementedException();
        }

        public RoleExtendDto? GetRoleByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<RoleExtendDto> GetRolesByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public RoleExtendDto SaveRole(RoleExtendDto role)
        {
            throw new NotImplementedException();
        }

        public RoleExtendDto UpdateRole(RoleExtendDto role)
        {
            throw new NotImplementedException();
        }

        public RoleExtendDto DeleteRole(RoleExtendDto role)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}