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
    /// Nombre: DepositController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IDepositService _depositService;

        #endregion

        #region Constructor

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpGet]
        [Route("GetDepositById")]
        [SwaggerOperation(Summary = "Get Deposit By Id")]
        public ResponseDto GetDepositById(int id)
        {
            try
            {
                response.Data = _depositService.GetDepositById(id);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByYearMonth")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month")]
        public ResponseDto GetDepositsByYearMonth(int year, int month)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonth(year, month);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByYearMonthAccount")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month Account")]
        public ResponseDto GetDepositsByYearMonthAccount(int year, int month, int idAccount)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthAccount(year, month, idAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByYearMonthStatus")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month Status")]
        public ResponseDto GetDepositsByYearMonthStatus(int year, int month, int idStatus)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthStatus(year, month, idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByYearMonthUser")]
        [SwaggerOperation(Summary = "Get Deposits By Year Month User")]
        public ResponseDto GetDepositsByYearMonthUser(int year, int month, int idUser)
        {
            try
            {
                response.Data = _depositService.GetDepositsByYearMonthUser(year, month, idUser);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByUser")]
        [SwaggerOperation(Summary = "Get Deposits By User")]
        public ResponseDto GetDepositsByUser(int idUser)
        {
            try
            {
                response.Data = _depositService.GetDepositsByUser(idUser);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByAccount")]
        [SwaggerOperation(Summary = "Get Deposits By Account")]
        public ResponseDto GetDepositsByAccount(int idAccount)
        {
            try
            {
                response.Data = _depositService.GetDepositsByAccount(idAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByStatus")]
        [SwaggerOperation(Summary = "Get Deposits By Status")]
        public ResponseDto GetDepositsByStatus(int idStatus)
        {
            try
            {
                response.Data = _depositService.GetDepositsByStatus(idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByUserStatus")]
        [SwaggerOperation(Summary = "Get Deposits By User Status")]
        public ResponseDto GetDepositsByUserStatus(int idUser, int idStatus)
        {
            try
            {
                response.Data = _depositService.GetDepositsByUserStatus(idUser, idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetDepositsByAccountStatus")]
        [SwaggerOperation(Summary = "Get Deposits By Account Status")]
        public ResponseDto GetDepositsByAccountStatus(int idAccount, int idStatus)
        {
            try
            {
                response.Data = _depositService.GetDepositsByAccountStatus(idAccount, idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveDeposit")]
        [SwaggerOperation(Summary = "Save Deposit")]
        public ResponseDto SaveDeposit(DepositExtendDto deposit)
        {
            try
            {
                response.Data = _depositService.SaveDeposit(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateDeposit")]
        [SwaggerOperation(Summary = "Update Deposit")]
        public ResponseDto UpdateDeposit(DepositExtendDto deposit)
        {
            try
            {
                response.Data = _depositService.UpdateDeposit(deposit);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteDeposit")]
        [SwaggerOperation(Summary = "Delete Deposit")]
        public ResponseDto DeleteDeposit(DepositExtendDto deposit)
        {
            try
            {
                response.Data = _depositService.DeleteDeposit(deposit);
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