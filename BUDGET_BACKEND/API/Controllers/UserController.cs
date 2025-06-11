namespace API.Controllers
{

    #region Librerias

    using CORE.Interfaces.Services;
    using CORE.Utils;
    using Domain.Dto;
    using Domain.Dto.Common;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IUserBudgetService _userService;

        #endregion

        #region Constructor

        public UserController(IUserBudgetService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetUserById")]
        [SwaggerOperation(Summary = "Get User By Id")]
        public ResponseDto GetUserById(UserDto user)
        {
            try
            {
                response.Data = _userService.GetUserById(user);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUserByEmail")]
        [SwaggerOperation(Summary = "Get User By Email")]
        public ResponseDto GetUserByEmail(UserDto user)
        {
            try
            {
                response.Data = _userService.GetUserByEmail(user);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUserByUsername")]
        [SwaggerOperation(Summary = "Get User By Username")]
        public ResponseDto GetUserByUsername(UserDto user)
        {
            try
            {
                response.Data = _userService.GetUserByUsername(user);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUsersByRole")]
        [SwaggerOperation(Summary = "Get Users By Role")]
        public ResponseDto GetUsersByRole(UserDto user)
        {
            try
            {
                response.Data = _userService.GetUsersByRole(user);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUsersByStatus")]
        [SwaggerOperation(Summary = "Get Users By Status")]
        public ResponseDto GetUsersByStatus(UserDto user)
        {
            try
            {
                response.Data = _userService.GetUsersByStatus(user);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUsersByRoleStatus")]
        [SwaggerOperation(Summary = "Get Users By Role Status")]
        public ResponseDto GetUsersByRoleStatus(UserDto user)
        {
            try
            {
                response.Data = _userService.GetUsersByRoleStatus(user);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveUser")]
        [SwaggerOperation(Summary = "Save User")]
        public ResponseDto SaveUser(UserDto user)
        {
            try
            {
                response.Data = _userService.SaveUser(user);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateUser")]
        [SwaggerOperation(Summary = "Update User")]
        public ResponseDto UpdateUser(UserDto user)
        {
            try
            {
                response.Data = _userService.UpdateUser(user);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteUser")]
        [SwaggerOperation(Summary = "Delete User")]
        public ResponseDto DeleteUser(UserDto user)
        {
            try
            {
                response.Data = _userService.DeleteUser(user);
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