namespace CORE.Services
{

    #region Librerias

    using CORE.Interfaces.Repositories;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingService : BaseService
    {

        #region Attributes

        #endregion Attributes

        #region Constructor

        public BillingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Constructor
    }
}
