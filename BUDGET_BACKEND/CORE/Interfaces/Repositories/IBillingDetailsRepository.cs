namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBillingDetailsRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBillingDetailsRepository
    {

        #region Métodos y Funciones

        public BillingDetailExtendDto? GetBillingDetailsById(int idBillingDetails);

        public List<BillingDetailExtendDto> GetBillingDetailsByBilling(int idBilling);

        public List<BillingDetailExtendDto> GetBillingDetailsByExpense(int idExpense);

        public List<BillingDetailExtendDto> GetBillingDetailsByStatus(int idStatus);

        public List<BillingDetailExtendDto> GetBillingDetailsByBillingExpense(int idBilling, int idExpense);

        public List<BillingDetailExtendDto> GetBillingDetailsByExpenseStatus(int idExpense, int idStatus);

        #endregion

    }
}