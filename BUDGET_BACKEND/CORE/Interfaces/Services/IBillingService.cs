namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBillingService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBillingService
    {

        #region Métodos y Funciones

        public BillingExtendDto? GetBillingById(int idBilling);

        public BillingExtendDto? GetBillingByYearMonthUser(int year, int month, int idUser);

        public List<BillingExtendDto> GetBillingsByUser(int idUser);

        public List<BillingExtendDto> GetBillingsByStatus(int idStatus);

        public List<BillingExtendDto> GetBillingsByUserStatus(int idUser, int idStatus);

        public BillingExtendDto SaveBilling(BillingExtendDto billing);

        public BillingExtendDto UpdateBilling(BillingExtendDto billing);

        public BillingExtendDto DeleteBilling(BillingExtendDto billing);

        #endregion 

    }
}