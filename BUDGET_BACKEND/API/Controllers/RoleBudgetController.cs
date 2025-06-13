namespace API.Controllers
{

    #region Librerias

    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Dto.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleBudgetController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleBudgetController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IRoleBudgetService _roleBudgetService;

        #endregion

        #region Constructor

        public RoleBudgetController(IRoleBudgetService roleBudgetService)
        {
            _roleBudgetService = roleBudgetService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpGet]
        [Route("GetRoleBudgetByIdRoleBudget")]
        [SwaggerOperation(Summary = "Get RoleBudget By IdRoleBudget")]
        public ResponseDto GetRoleBudgetByIdRoleBudget(RoleBudgetDto roleBudget)
        {
            try
            {
                response.Data = _roleBudgetService.GetRoleBudgetByIdRoleBudget(roleBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetRoleBudgetByNameRole")]
        [SwaggerOperation(Summary = "Get RoleBudget By NameRole")]
        public ResponseDto GetRoleBudgetByNameRole(RoleBudgetDto roleBudget)
        {
            try
            {
                response.Data = _roleBudgetService.GetRoleBudgetByNameRole(roleBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetRolesBudgetByStatusBudget")]
        [SwaggerOperation(Summary = "Get RolesBudget By StatusBudget")]
        public ResponseDto GetRolesBudgetByStatusBudget(RoleBudgetDto roleBudget)
        {
            try
            {
                response.Data = _roleBudgetService.GetRolesBudgetByStatusBudget(roleBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveRoleBudget")]
        [SwaggerOperation(Summary = "Save RoleBudget")]
        public ResponseDto SaveRoleBudget(RoleBudgetDto roleBudget)
        {
            try
            {
                response.Data = _roleBudgetService.SaveRoleBudget(roleBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateRoleBudget")]
        [SwaggerOperation(Summary = "Update RoleBudget")]
        public ResponseDto UpdateRoleBudget(RoleBudgetDto roleBudget)
        {
            try
            {
                response.Data = _roleBudgetService.UpdateRoleBudget(roleBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteRoleBudget")]
        [SwaggerOperation(Summary = "Delete RoleBudget")]
        public ResponseDto DeleteRoleBudget(RoleBudgetDto roleBudget)
        {
            try
            {
                response.Data = _roleBudgetService.DeleteRoleBudget(roleBudget);
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