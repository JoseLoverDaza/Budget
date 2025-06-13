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
    /// Nombre: TokenApiController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenApiController : BaseController
    {

        #region Atributos y Propiedades

        private readonly ITokenApiService _tokenApiService;

        #endregion

        #region Constructor

        public TokenApiController(ITokenApiService tokenApiService)
        {
            _tokenApiService = tokenApiService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetTokenApiByIdTokenApi")]
        [SwaggerOperation(Summary = "Get TokenApi By IdTokenApi")]
        public ResponseDto GetTokenApiByIdTokenApi(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApiByIdTokenApi(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApiByToken")]
        [SwaggerOperation(Summary = "Get Token Api By Token")]
        public ResponseDto GetTokenApiByToken(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApiByToken(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByCreationDate")]
        [SwaggerOperation(Summary = "Get Token Apis By Creation Date")]
        public ResponseDto GetTokenApisByCreationDate(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByCreationDate(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByUserBudget")]
        [SwaggerOperation(Summary = "Get TokenApis By UserBudget")]
        public ResponseDto GetTokenApisByUserBudget(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByUserBudget(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByStatusBudget")]
        [SwaggerOperation(Summary = "Get TokenApis By StatusBudget")]
        public ResponseDto GetTokenApisByStatusBudget(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByStatusBudget(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByCreationDateStatusBudget")]
        [SwaggerOperation(Summary = "Get TokenApis By CreationDate StatusBudget")]
        public ResponseDto GetTokenApisByCreationDateStatusBudget(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByCreationDateStatusBudget(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByExpirationDateStatusBudget")]
        [SwaggerOperation(Summary = "Get TokenApis By ExpirationDate StatusBudget")]
        public ResponseDto GetTokenApisByExpirationDateStatusBudget(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByExpirationDateStatusBudget(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByUserBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get TokenApis By UserBudget StatusBudget")]
        public ResponseDto GetTokenApisByUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByUserBudgetStatusBudget(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByCreationDateUserBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get TokenApis By CreationDate UserBudget StatusBudget")]
        public ResponseDto GetTokenApisByCreationDateUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByCreationDateUserBudgetStatusBudget(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByExpirationDateUserBudgetStatusBudget")]
        [SwaggerOperation(Summary = "Get TokenApis By ExpirationDate UserBudget StatusBudget")]
        public ResponseDto GetTokenApisByExpirationDateUserBudgetStatusBudget(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByExpirationDateUserBudgetStatusBudget(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveTokenApi")]
        [SwaggerOperation(Summary = "Save Token Api")]
        public ResponseDto SaveTokenApi(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.SaveTokenApi(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateTokenApi")]
        [SwaggerOperation(Summary = "Update Token Api")]
        public ResponseDto UpdateTokenApi(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.UpdateTokenApi(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteTokenApi")]
        [SwaggerOperation(Summary = "Delete Token Api")]
        public ResponseDto DeleteTokenApi(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.DeleteTokenApi(tokenApi);
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