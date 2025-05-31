namespace CORE.Services
{

    #region Librerias

    using CORE.Dto;
    using CORE.Interfaces.Repositories;
    using CORE.Interfaces.Services;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingService : BaseService, IBillingService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public BillingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public BillingExtendDto? GetBillingById(int idBilling)
        {
            throw new NotImplementedException();
        }

        public BillingExtendDto? GetBillingByYearMonthUser(int year, int month, int idUser)
        {
            throw new NotImplementedException();
        }

        public List<BillingExtendDto> GetBillingsByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<BillingExtendDto> GetBillingsByUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public List<BillingExtendDto> GetBillingsByUserStatus(int idUser, int idStatus)
        {
            throw new NotImplementedException();
        }

        public BillingExtendDto SaveBilling(BillingExtendDto billing)
        {
            throw new NotImplementedException();
        }

        public BillingExtendDto UpdateBilling(BillingExtendDto billing)
        {
            throw new NotImplementedException();
        }

        public BillingExtendDto DeleteBilling(BillingExtendDto billing)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}