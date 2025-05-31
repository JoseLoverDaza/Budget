namespace CORE.Services
{

    #region Librerias

    using CORE.Interfaces.Repositories;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class StatusService : BaseService
    {

        #region Attributes

        #endregion Attributes

        #region Constructor

        public StatusService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Constructor

    }
}