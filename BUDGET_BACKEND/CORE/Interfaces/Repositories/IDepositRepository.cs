namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IDepositRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IDepositRepository
    {

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositById(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonth(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearUser(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByMonthUser(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonthUser(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonthAccount(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonthStatus(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByYearMonthUserAccount(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByUser(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByAccount(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByStatus(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByUserStatus(DepositDto deposit);

        public List<DepositExtendDto> GetDepositsByAccountStatus(DepositDto deposit);

        #endregion

    }
}