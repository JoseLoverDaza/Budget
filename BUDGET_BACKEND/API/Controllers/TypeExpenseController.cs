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

        [HttpPost]
        [Route("GetTypeExpenseById")]
        [SwaggerOperation(Summary = "Get Type Expense By Id")]
        public ResponseDto GetTypeExpenseById(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpenseById(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTypeExpenseByName")]
        [SwaggerOperation(Summary = "Get Type Expense By Name")]
        public ResponseDto GetTypeExpenseByName(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpenseByName(typeExpense);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetTypeExpensesByStatus")]
        [SwaggerOperation(Summary = "Get Type Expenses By Status")]
        public ResponseDto GetTypeExpensesByStatus(TypeExpenseDto typeExpense)
        {
            try
            {
                response.Data = _typeExpenseService.GetTypeExpensesByStatus(typeExpense);
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
        public ResponseDto SaveTypeExpense(TypeExpenseDto typeExpense)
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
        public ResponseDto UpdateTypeExpense(TypeExpenseDto typeExpense)
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
        public ResponseDto DeleteTypeExpense(TypeExpenseDto typeExpense)
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
