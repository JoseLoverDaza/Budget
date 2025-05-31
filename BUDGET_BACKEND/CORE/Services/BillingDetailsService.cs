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
    /// Nombre: BillingDetailsService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingDetailsService : BaseService, IBillingDetailsService
    {

        #region Atributos y Propiedades

        #endregion

        #region Constructor

        public BillingDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Métodos y Funciones

        public BillingDetailExtendDto? GetBillingDetailsById(int idBillingDetails)
        {
            throw new NotImplementedException();
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByExpense(int idExpense)
        {
            throw new NotImplementedException();
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByExpenseStatus(int idExpense, int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<BillingDetailExtendDto> GetBillingDetailsByStatus(int idStatus)
        {
            throw new NotImplementedException();
        }

        public BillingDetailExtendDto SaveBillingDetail(BillingDetailExtendDto billingDetail)
        {
            throw new NotImplementedException();
        }

        public BillingDetailExtendDto UpdateBillingDetail(BillingDetailExtendDto billingDetail)
        {
            throw new NotImplementedException();
        }

        public BillingDetailExtendDto DeleteBillingDetail(BillingDetailExtendDto billingDetail)
        {
            throw new NotImplementedException();
        }

        #endregion Constructor

    }
}