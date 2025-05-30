using CORE.Interfaces.Repositories;

namespace CORE.Services
{

    #region Using

    

    #endregion Using

    public class BaseService
    {

        #region Attributes

        protected internal IUnitOfWork UnitOfWork { get; set; }

        #endregion Attributes

        #region Constructor

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Métodos y Funciones

        public IUnitOfWork GeNewtInstanceUnitOfWork()
        {
            return UnitOfWork.GetNewInstanceUnitOfWork();
        }

        #endregion Methods

    }
}