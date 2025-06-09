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
    /// Nombre: TokenApiController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

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
        [Route("GetTokenApiById")]
        [SwaggerOperation(Summary = "Get Token Api By Id")]
        public ResponseDto GetTokenApiById(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApiById(tokenApi);
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
        [Route("GetTokenApisByUser")]
        [SwaggerOperation(Summary = "Get Token Apis By User")]
        public ResponseDto GetTokenApisByUser(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByUser(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByStatus")]
        [SwaggerOperation(Summary = "Get Token Apis By Status")]
        public ResponseDto GetTokenApisByStatus(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByStatus(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByCreationDateStatus")]
        [SwaggerOperation(Summary = "Get Token Apis By Creation Date Status")]
        public ResponseDto GetTokenApisByCreationDateStatus(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByCreationDateStatus(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByExpirationDateStatus")]
        [SwaggerOperation(Summary = "Get Token Apis By Expiration Date Status")]
        public ResponseDto GetTokenApisByExpirationDateStatus(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByExpirationDateStatus(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByUserStatus")]
        [SwaggerOperation(Summary = "Get Token Apis By User Status")]
        public ResponseDto GetTokenApisByUserStatus(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByUserStatus(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByCreationDateUserStatus")]
        [SwaggerOperation(Summary = "Get Token Apis By Creation Date User Status")]
        public ResponseDto GetTokenApisByCreationDateUserStatus(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByCreationDateUserStatus(tokenApi);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTokenApisByExpirationDateUserStatus")]
        [SwaggerOperation(Summary = "Get Token Apis By Expiration Date User Status")]
        public ResponseDto GetTokenApisByExpirationDateUserStatus(TokenApiDto tokenApi)
        {
            try
            {
                response.Data = _tokenApiService.GetTokenApisByExpirationDateUserStatus(tokenApi);
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