namespace CORE.Services
{

    #region Librerias

    using CORE.Interfaces.Repositories;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ExpenseService : BaseService
    {

        #region Attributes

        #endregion Attributes

        #region Constructor

        public ExpenseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Constructor

    }
}