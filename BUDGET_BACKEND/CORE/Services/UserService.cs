namespace CORE.Services
{

    #region Librerias

    using CORE.Interfaces.Repositories;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UserService : BaseService
    {

        #region Attributes

        #endregion Attributes

        #region Constructor

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Constructor

    }
}