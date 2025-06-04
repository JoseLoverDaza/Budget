namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBillingRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBillingRepository
    {

        #region Métodos y Funciones

        public BillingExtendDto? GetBillingById(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByYearMonth(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByYearUser(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByMonthUser(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByYearMonthUser(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByUser(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByStatus(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByUserStatus(BillingDto billing);

        #endregion 

    }
}