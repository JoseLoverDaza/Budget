namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

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
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();

            RoleExtendDto? role = roleRepository.GetRoleById(idRole);

            if (role != null)
            {
                return role;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public RoleExtendDto? GetRoleByName(string name)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();

            RoleExtendDto? role = roleRepository.GetRoleByName(name);

            if (role != null)
            {
                return role;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<RoleExtendDto> GetRolesByStatus(int idStatus)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            List<RoleExtendDto> roles = roleRepository.GetRolesByStatus(idStatus);

            if (roles.Count != 0)
            {
                return roles;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public RoleExtendDto SaveRole(RoleExtendDto role)
        {           
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (role == null || string.IsNullOrWhiteSpace(role.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(role.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleExtendDto? roleSearch = roleRepository.GetRoleByName(role.Name.Trim());

            if (roleSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(role.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Role saveRole = new()
            {
                Name = role.Name.Trim(),
                Description = role.Description!.Trim(),
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Role>().Add(saveRole);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return role;
        }

        public RoleExtendDto UpdateRole(RoleExtendDto role)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            
            if (role == null || role.IdRole <= 0 || string.IsNullOrWhiteSpace(role.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            if (!Regex.IsMatch(role.Name.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleExtendDto? roleDuplicado = roleRepository.GetRoleByName(role.Name);
            RoleExtendDto? roleSearch = roleRepository.GetRoleById(role.IdRole) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (roleDuplicado != null && roleDuplicado.IdRole != roleSearch.IdRole)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Role updateRole = new()
            {
                IdRole = roleSearch.IdRole,
                Name = role.Name.Trim(),
                Description = role.Description!.Trim(),
                IdStatus = roleSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Role>().Update(updateRole);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return role;
        }

        public RoleExtendDto DeleteRole(RoleExtendDto role)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            RoleExtendDto? roleSearch = roleRepository.GetRoleById(role.IdRole) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(role.IdStatus) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (roleSearch.IdStatus == role.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Role deleteRole = new()
            {
                IdRole = roleSearch.IdRole,
                Name = roleSearch.Name.Trim(),
                Description = roleSearch.Description!.Trim(),
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Role>().Update(deleteRole);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            return role;
        }

        #endregion

    }
}