namespace CORE.Services
{

    #region Librerias

    using CORE.Interfaces.Repositories;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetService : BaseService
    {

        #region Attributes

        #endregion Attributes

        #region Constructor

        public BudgetService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Constructor

    }
}