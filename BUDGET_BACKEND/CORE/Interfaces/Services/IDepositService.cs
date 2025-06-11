namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IDepositService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IDepositService
    {

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositByIdDeposit(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonth(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearUserBudget(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByMonthUserBudget(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonthUserBudget(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonthStatusBudget(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonthUserBudgetAccount(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByUserBudget(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByAccount(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByStatusBudget(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByUserBudgetStatusBudget(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByAccountStatusBudget(DepositDto deposit);

        public DepositDto SaveDeposit(DepositDto deposit);

        public DepositDto UpdateDeposit(DepositDto deposit);

        public DepositDto DeleteDeposit(DepositDto deposit);

        #endregion

    }
}