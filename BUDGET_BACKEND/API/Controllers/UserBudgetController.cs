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
    /// Nombre: UserBudgetController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserBudgetController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IUserBudgetService _userService;

        #endregion

        #region Constructor

        public UserBudgetController(IUserBudgetService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetUserBudgetByIdUserBudget")]
        [SwaggerOperation(Summary = "Get UserBudget By IdUserBudget")]
        public ResponseDto GetUserBudgetByIdUserBudget(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.GetUserBudgetByIdUserBudget(userBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUserBudgetByEmail")]
        [SwaggerOperation(Summary = "Get UserBudget By Email")]
        public ResponseDto GetUserBudgetByEmail(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.GetUserBudgetByEmail(userBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUserBudgetByUsername")]
        [SwaggerOperation(Summary = "Get UserBudget By Username")]
        public ResponseDto GetUserBudgetByUsername(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.GetUserBudgetByUsername(userBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUsersBudgetByRoleBudget")]
        [SwaggerOperation(Summary = "Get UsersBudget By RoleBudget")]
        public ResponseDto GetUsersBudgetByRoleBudget(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.GetUsersBudgetByRoleBudget(userBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUsersBudgetByStatusBudget")]
        [SwaggerOperation(Summary = "Get UsersBudget By StatusBudget")]
        public ResponseDto GetUsersBudgetByStatusBudget(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.GetUsersBudgetByStatusBudget(userBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetUsersBudgetByRoleBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get UsersBudget By RoleBudget StatusBudget")]
        public ResponseDto GetUsersBudgetByRoleBudgetStatusBudget(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.GetUsersBudgetByRoleBudgetStatusBudget(userBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveUserBudget")]
        [SwaggerOperation(Summary = "Save UserBudget")]
        public ResponseDto SaveUserBudget(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.SaveUserBudget(userBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateUserBudget")]
        [SwaggerOperation(Summary = "Update UserBudget")]
        public ResponseDto UpdateUserBudget(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.UpdateUserBudget(userBudget);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteUserBudget")]
        [SwaggerOperation(Summary = "Delete UserBudget")]
        public ResponseDto DeleteUserBudget(UserBudgetDto userBudget)
        {
            try
            {
                response.Data = _userService.DeleteUserBudget(userBudget);
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