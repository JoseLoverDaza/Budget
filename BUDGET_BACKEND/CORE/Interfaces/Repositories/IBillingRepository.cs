namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBillingRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBillingRepository
    {

        #region Métodos y Funciones

        public BillingExtendDto? GetBillingById(int idBilling);

        public BillingExtendDto? GetBillingByYearMonthUser(int year, int month, int idUser);

        public List<BillingExtendDto> GetBillingsByUser(int idUser);

        public List<BillingExtendDto> GetBillingsByStatus(int idStatus);

        public List<BillingExtendDto> GetBillingsByUserStatus(int idUser, int idStatus);

        #endregion 

    }
}