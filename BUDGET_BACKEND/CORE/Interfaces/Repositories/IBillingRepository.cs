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

        public BillingExtendDto? GetBillingByIdBilling(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByYearMonth(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByYearMonthStatusBudget(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByYearUserBudget(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByMonthUserBudget(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByYearMonthUserBudget(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByUserBudget(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByStatusBudget(BillingDto billing);

        public List<BillingExtendDto> GetBillingsByUserBudgetStatusBudget(BillingDto billing);

        #endregion 

    }
}