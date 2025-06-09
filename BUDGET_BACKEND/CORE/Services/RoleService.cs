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
    using System.Text.Json;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class RoleService : BaseService, IRoleService
    {

        #region Atributos y Propiedades

        private readonly ILogApiService _logApiService;

        #endregion

        #region Constructor

        public RoleService(IUnitOfWork unitOfWork, ILogApiService logApiService) : base(unitOfWork)
        {
            _logApiService = logApiService;
        }

        #endregion

        #region Métodos y Funciones

        public RoleExtendDto? GetRoleById(RoleDto role)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            RoleExtendDto? roleSearch = roleRepository.GetRoleById(role);

            _logApiService.TraceLog(typeof(Role).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (roleSearch != null)
            {
                return roleSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public RoleExtendDto? GetRoleByName(RoleDto role)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            RoleExtendDto? roleSearch = roleRepository.GetRoleByName(role);

            _logApiService.TraceLog(typeof(Role).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (roleSearch != null)
            {
                return roleSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public List<RoleExtendDto> GetRolesByStatus(RoleDto role)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            List<RoleExtendDto> rolesSearch = roleRepository.GetRolesByStatus(role);

            _logApiService.TraceLog(typeof(Role).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(Constants.General.JSON_EMPTY), DateTime.Now, null);

            if (rolesSearch.Count != 0)
            {
                return rolesSearch;
            }
            else
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
        }

        public RoleDto SaveRole(RoleDto role)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            if (role == null || string.IsNullOrWhiteSpace(role.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleExtendDto? roleSearch = roleRepository.GetRoleByName(role);

            if (roleSearch != null)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = role.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            Role saveRole = new()
            {
                Name = role.Name.Trim(),
                Description = role.Description?.Trim() ?? string.Empty,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Role>().Add(saveRole);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Role).Name, Constants.Method.POST, JsonSerializer.Serialize(Constants.General.JSON_EMPTY), JsonSerializer.Serialize(saveRole), DateTime.Now, null);

            return role;
        }

        public RoleDto UpdateRole(RoleDto role)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();

            if (role == null || role.IdRole <= 0 || string.IsNullOrWhiteSpace(role.Name.Trim()))
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            RoleExtendDto? roleDuplicado = roleRepository.GetRoleByName(role);
            RoleExtendDto? roleSearch = roleRepository.GetRoleById(role) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (roleDuplicado != null && roleDuplicado.IdRole != roleSearch.IdRole)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Role updateRole = new()
            {
                IdRole = roleSearch.IdRole,
                Name = role.Name.Trim(),
                Description = role.Description?.Trim() ?? string.Empty,
                IdStatus = roleSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Role>().Update(updateRole);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            _logApiService.TraceLog(typeof(Role).Name, Constants.Method.POST, JsonSerializer.Serialize(roleSearch), JsonSerializer.Serialize(updateRole), DateTime.Now, null);

            return role;
        }

        public RoleDto DeleteRole(RoleDto role)
        {
            IRoleRepository roleRepository = UnitOfWork.RoleRepository();
            IStatusRepository statusRepository = UnitOfWork.StatusRepository();

            RoleExtendDto? roleSearch = roleRepository.GetRoleById(role) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            StatusDto? statusSearch = statusRepository.GetStatusById(new StatusDto { IdStatus = role.IdStatus }) ?? throw new ExternalException(Constants.General.MESSAGE_GENERAL);

            if (roleSearch.IdStatus == role.IdStatus)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }

            Role deleteRole = new()
            {
                IdRole = roleSearch.IdRole,
                Name = roleSearch.Name.Trim(),
                Description = roleSearch.Description?.Trim() ?? string.Empty,
                IdStatus = statusSearch.IdStatus
            };

            UnitOfWork.BaseRepository<Role>().Update(deleteRole);

            if (UnitOfWork.SaveChanges() <= 0)
            {
                throw new ExternalException(Constants.General.MESSAGE_GENERAL);
            }
            _logApiService.TraceLog(typeof(Role).Name, Constants.Method.POST, JsonSerializer.Serialize(roleSearch), JsonSerializer.Serialize(deleteRole), DateTime.Now, null);

            return role;
        }

        #endregion

    }
}