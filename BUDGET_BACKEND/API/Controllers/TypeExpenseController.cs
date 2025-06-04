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
    /// Nombre: TypeExpenseController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class TypeExpenseController : BaseController
    {

        #region Atributos y Propiedades

        private readonly ITypeExpenseService _typeExpenseService;

        #endregion

        #region Constructor

        public TypeExpenseController(ITypeExpenseService typeExpenseService)
        {
            _typeExpenseService = typeExpenseService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpGet]
        [Route("GetTypeExpenseById")]
        [SwaggerOperation(Summary = "Get Type Expense By Id")]
        public ResponseDto GetTypeExpenseById(int id)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpenseById(id);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetTypeExpenseByName")]
        [SwaggerOperation(Summary = "Get Type Expense By Name")]
        public ResponseDto GetTypeExpenseByName(string name)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpenseByName(name);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetTypeExpensesByStatus")]
        [SwaggerOperation(Summary = "Get Type Expenses By Status")]
        public ResponseDto GetTypeExpensesByStatus(int idStatus)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpensesByStatus(idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveTypeExpense")]
        [SwaggerOperation(Summary = "Save Type Expense")]
        public ResponseDto SaveTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.SaveTypeExpense(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateTypeExpense")]
        [SwaggerOperation(Summary = "Update Type Expense")]
        public ResponseDto UpdateTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.UpdateTypeExpense(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteTypeExpense")]
        [SwaggerOperation(Summary = "Delete Type Expense")]
        public ResponseDto DeleteTypeExpense(TypeExpenseExtendDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.DeleteTypeExpense(typeExpense);
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
