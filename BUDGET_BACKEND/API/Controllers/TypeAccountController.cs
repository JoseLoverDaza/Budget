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
        [Route("GetTypeAccountById")]
        [SwaggerOperation(Summary = "Get Type Account By Id")]
        public ResponseDto GetTypeAccountById(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.GetTypeAccountById(typeAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetTypeAccountByName")]
        [SwaggerOperation(Summary = "Get Type Account By Name")]
        public ResponseDto GetTypeAccountByName(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.GetTypeAccountByName(typeAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetTypeAccountsByStatus")]
        [SwaggerOperation(Summary = "Get Type Accounts By Status")]
        public ResponseDto GetTypeAccountsByStatus(TypeAccountDto typeAccount)
        {
            try
            {
                response.Data = _typeAccountService.GetTypeAccountsByStatus(typeAccount);
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