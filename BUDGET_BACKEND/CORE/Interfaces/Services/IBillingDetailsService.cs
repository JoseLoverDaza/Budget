namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBillingDetailsService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBillingDetailsService
    {

        #region Métodos y Funciones

        public BillingDetailExtendDto? GetBillingDetailsById(BillingDetailsDto billingDetails);

        public List<BillingDetailExtendDto> GetBillingDetailsByBilling(BillingDetailsDto billingDetails);

        public List<BillingDetailExtendDto> GetBillingDetailsByExpense(BillingDetailsDto billingDetails);

        public List<BillingDetailExtendDto> GetBillingDetailsByStatus(BillingDetailsDto billingDetails);

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpense(BillingDetailsDto billingDetails);

        public List<BillingDetailExtendDto> GetBillingDetailsByExpenseStatus(BillingDetailsDto billingDetails);

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpenseStatus(BillingDetailsDto billingDetails);

        public BillingDetailsDto SaveBillingDetail(BillingDetailsDto billingDetails);

        public BillingDetailsDto UpdateBillingDetail(BillingDetailsDto billingDetails);

        public BillingDetailsDto DeleteBillingDetail(BillingDetailsDto billingDetails);

        #endregion

    }
}