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
    /// Nombre: TypeAccountController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class TypeAccountController : BaseController
    {

        #region Atributos y Propiedades

        private readonly ITypeAccountService _typeAccountService;

        #endregion

        #region Constructor

        public TypeAccountController(ITypeAccountService typeAccountService)
        {
            _typeAccountService = typeAccountService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpGet]
        [Route("GetTypeAccountByIdTypeAccount")]
        [SwaggerOperation(Summary = "Get TypeAccount By IdTypeAccount")]
        public ResponseDto GetTypeAccountByIdTypeAccount(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.GetTypeAccountByIdTypeAccount(typeAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetTypeAccountByNameTypeAccount")]
        [SwaggerOperation(Summary = "Get TypeAccount By NameTypeAccount")]
        public ResponseDto GetTypeAccountByNameTypeAccount(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.GetTypeAccountByNameTypeAccount(typeAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetTypeAccountsByStatusBudget")]
        [SwaggerOperation(Summary = "Get TypeAccounts By StatusBudget")]
        public ResponseDto GetTypeAccountsByStatusBudget(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.GetTypeAccountsByStatusBudget(typeAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveTypeAccount")]
        [SwaggerOperation(Summary = "Save Type Account")]
        public ResponseDto SaveTypeAccount(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.SaveTypeAccount(typeAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateTypeAccount")]
        [SwaggerOperation(Summary = "Update Type Account")]
        public ResponseDto UpdateTypeAccount(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.UpdateTypeAccount(typeAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteTypeAccount")]
        [SwaggerOperation(Summary = "Delete Type Account")]
        public ResponseDto DeleteTypeAccount(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.DeleteTypeAccount(typeAccount);
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