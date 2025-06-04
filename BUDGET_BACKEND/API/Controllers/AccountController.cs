namespace API.Controllers
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Services;
    using CORE.Services;
    using CORE.Utils;
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

        [HttpGet]
        [Route("GetAccountById")]
        [SwaggerOperation(Summary = "Get Account By Id")]
        public ResponseDto GetAccountById(int id)
        {
            try
            {
                response.Data = _accountService.GetAccountById(id);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByFinancialInstitution")]
        [SwaggerOperation(Summary = "Get Accounts By Financial Institution")]
        public ResponseDto GetAccountsByFinancialInstitution(int idFinancialInstitution)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitution(idFinancialInstitution);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByTypeAccount")]
        [SwaggerOperation(Summary = "Get Accounts By Type Account")]
        public ResponseDto GetAccountsByTypeAccount(int idTypeAccount)
        {
            try
            {
                response.Data = _accountService.GetAccountsByTypeAccount(idTypeAccount);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByUser")]
        [SwaggerOperation(Summary = "Get Accounts By User")]
        public ResponseDto GetAccountsByUser(int idUser)
        {
            try
            {
                response.Data = _accountService.GetAccountsByUser(idUser);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByStatus")]
        [SwaggerOperation(Summary = "Get Accounts By Status")]
        public ResponseDto GetAccountsByStatus(int idStatus)
        {
            try
            {
                response.Data = _accountService.GetAccountsByStatus(idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByFinancialInstitutionStatus")]
        [SwaggerOperation(Summary = "Get Accounts By Financial InstitutionStatus")]
        public ResponseDto GetAccountsByFinancialInstitutionStatus(int idFinancialInstitution, int idStatus)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitutionStatus(idFinancialInstitution, idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByTypeAccountStatus")]
        [SwaggerOperation(Summary = "Get Accounts By Type Account Status")]
        public ResponseDto GetAccountsByTypeAccountStatus(int idTypeAccount, int idStatus)
        {
            try
            {
                response.Data = _accountService.GetAccountsByTypeAccountStatus(idTypeAccount, idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByUserStatus")]
        [SwaggerOperation(Summary = "Get Accounts By User Status")]
        public ResponseDto GetAccountsByUserStatus(int idUser, int idStatus)
        {
            try
            {
                response.Data = _accountService.GetAccountsByUserStatus(idUser, idStatus);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByNameFinancialInstitutionTypeAccountUser")]
        [SwaggerOperation(Summary = "Get Accounts By Name Financial Institution Type Account User")]
        public ResponseDto GetAccountsByNameFinancialInstitutionTypeAccountUser(string name, int idFinancialInstitution, int idTypeAccount, int idUser)
        {
            try
            {
                response.Data = _accountService.GetAccountsByNameFinancialInstitutionTypeAccountUser(name, idFinancialInstitution, idTypeAccount, idUser);
                response.Message = Constants.General.SUCCESSUL;
            }
            catch (Exception ex)
            {
                ResponseError(ex, true);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAccountsByFinancialInstitutionTypeAccountUser")]
        [SwaggerOperation(Summary = "Get Accounts By Financial Institution Type Account User")]
        public ResponseDto GetAccountsByFinancialInstitutionTypeAccountUser(int idFinancialInstitution, int idTypeAccount, int idUser)
        {
            try
            {
                response.Data = _accountService.GetAccountsByFinancialInstitutionTypeAccountUser(idFinancialInstitution, idTypeAccount, idUser);
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
        public ResponseDto SaveAccount(AccountExtendDto account)
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
        public ResponseDto UpdateAccount(AccountExtendDto account)
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
        [SwaggerOperation(Summary = "DeleteAccount")]
        public ResponseDto DeleteAccount(AccountExtendDto account)
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