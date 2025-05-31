namespace CORE.Services
{

    #region Librerias

    using CORE.Interfaces.Repositories;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AccountService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AccountService : BaseService
    {

        #region Attributes

        #endregion Attributes

        #region Constructor

        public AccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Constructor

    }
}
