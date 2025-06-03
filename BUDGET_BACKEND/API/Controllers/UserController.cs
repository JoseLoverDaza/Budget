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
    /// Nombre: UserController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpGet]
        [Route("GetUserById")]
        [SwaggerOperation(Summary = "Get User By Id")]
        public ResponseDto GetUserById(int id)
        {
            try
            {
                response.Data = _userService.GetUserById(id);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetUserByEmail")]
        [SwaggerOperation(Summary = "Get User By Email")]
        public ResponseDto GetUserByEmail(string email)
        {
            try
            {
                response.Data = _userService.GetUserByEmail(email);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetUserByLogin")]
        [SwaggerOperation(Summary = "Get User By Login")]
        public ResponseDto GetUserByLogin(string login)
        {
            try
            {
                response.Data = _userService.GetUserByLogin(login);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetUsersByRole")]
        [SwaggerOperation(Summary = "Get Users By Role")]
        public ResponseDto GetUsersByRole(int idRole)
        {
            try
            {
                response.Data = _userService.GetUsersByRole(idRole);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetUsersByStatus")]
        [SwaggerOperation(Summary = "Get Users By Status")]
        public ResponseDto GetUsersByStatus(int idStatus)
        {
            try
            {
                response.Data = _userService.GetUsersByStatus(idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetUsersByRoleStatus")]
        [SwaggerOperation(Summary = "Get Users By Role Status")]
        public ResponseDto GetUsersByRoleStatus(int idRole, int idStatus)
        {
            try
            {
                response.Data = _userService.GetUsersByRoleStatus(idRole, idStatus);
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
        public ResponseDto SaveUser(UserExtendDto user)
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
        public ResponseDto UpdateUser(UserExtendDto user)
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
        public ResponseDto DeleteUser(UserExtendDto user)
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