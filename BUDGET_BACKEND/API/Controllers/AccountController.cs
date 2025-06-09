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
    /// Nombre: AccountController   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {

        #region Atributos y Propiedades

        private readonly IAccountService _accountService;

        #endregion

        #region Constructor

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #endregion

        #region Métodos y Funciones

        [HttpPost]
        [Route("GetAccountById")]
        [SwaggerOperation(Summary = "Get Account By Id")]
        public ResponseDto GetAccountById(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountById(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByFinancialInstitution")]
        [SwaggerOperation(Summary = "Get Accounts By Financial Institution")]
        public ResponseDto GetAccountsByFinancialInstitution(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitution(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByTypeAccount")]
        [SwaggerOperation(Summary = "Get Accounts By Type Account")]
        public ResponseDto GetAccountsByTypeAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByTypeAccount(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByUser")]
        [SwaggerOperation(Summary = "Get Accounts By User")]
        public ResponseDto GetAccountsByUser(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByUser(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByStatus")]
        [SwaggerOperation(Summary = "Get Accounts By Status")]
        public ResponseDto GetAccountsByStatus(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByStatus(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByFinancialInstitutionStatus")]
        [SwaggerOperation(Summary = "Get Accounts By Financial InstitutionStatus")]
        public ResponseDto GetAccountsByFinancialInstitutionStatus(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitutionStatus(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByTypeAccountStatus")]
        [SwaggerOperation(Summary = "Get Accounts By Type Account Status")]
        public ResponseDto GetAccountsByTypeAccountStatus(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByTypeAccountStatus(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByUserStatus")]
        [SwaggerOperation(Summary = "Get Accounts By User Status")]
        public ResponseDto GetAccountsByUserStatus(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByUserStatus(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByNameFinancialInstitutionTypeAccountUser")]
        [SwaggerOperation(Summary = "Get Accounts By Name Financial Institution Type Account User")]
        public ResponseDto GetAccountsByNameFinancialInstitutionTypeAccountUser(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByNameFinancialInstitutionTypeAccountUser(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("GetAccountsByFinancialInstitutionTypeAccountUser")]
        [SwaggerOperation(Summary = "Get Accounts By Financial Institution Type Account User")]
        public ResponseDto GetAccountsByFinancialInstitutionTypeAccountUser(AccountDto account)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitutionTypeAccountUser(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveAccount")]
        [SwaggerOperation(Summary = "Save Account")]
        public ResponseDto SaveAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.SaveAccount(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateAccount")]
        [SwaggerOperation(Summary = "Update Account")]
        public ResponseDto UpdateAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.UpdateAccount(account);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpPost]
        [Route("DeleteAccount")]
        [SwaggerOperation(Summary = "Delete Account")]
        public ResponseDto DeleteAccount(AccountDto account)
        {
            try
            {
                response.Data = _accountService.DeleteAccount(account);
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