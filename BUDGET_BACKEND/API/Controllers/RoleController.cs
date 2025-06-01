namespace API.Controllers
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto.Common;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IRoleService _roleService;

        #endregion

        #region Constructor

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpGet]
        [Route("GetRoleById")]
        [SwaggerOperation(Summary = "Get Role By Id")]
        public ResponseDto GetRoleById(int id)
        {
            try
            {
                response.Data = _roleService.GetRoleById(id);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetRoleByName")]
        [SwaggerOperation(Summary = "Get Role By Name")]
        public ResponseDto GetRoleByName(string name)
        {
            try
            {
                response.Data = _roleService.GetRoleByName(name);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetRolesByStatus")]
        [SwaggerOperation(Summary = "Get Roles By Status")]
        public ResponseDto GetRolesByStatus(int idStatus)
        {
            try
            {
                response.Data = _roleService.GetRolesByStatus(idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveRole")]
        [SwaggerOperation(Summary = "Save Role")]
        public ResponseDto SaveRole(RoleExtendDto role)
        {
            try
            {
                response.Data = _roleService.SaveRole(role);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateRole")]
        [SwaggerOperation(Summary = "Update Role")]
        public ResponseDto UpdateRole(RoleExtendDto role)
        {
            try
            {
                response.Data = _roleService.UpdateRole(role);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteRole")]
        [SwaggerOperation(Summary = "Delete Role")]
        public ResponseDto DeleteRole(RoleExtendDto role)
        {
            try
            {
                response.Data = _roleService.DeleteRole(role);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        #endregion

    }
}