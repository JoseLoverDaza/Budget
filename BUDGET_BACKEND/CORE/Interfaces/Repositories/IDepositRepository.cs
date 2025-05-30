namespace CORE.Interfaces.Repositories
{

    #region Using

    using CORE.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IDepositRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IDepositRepository
    {

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositById(int id);

        public DepositExtendDto? GetDepositByName(string name);

        public List<DepositExtendDto> GetDepositsByUser(int user);

        public List<DepositExtendDto> GetDepositsByAccount(int account);

        public List<DepositExtendDto> GetDepositsByStatus(int status);

        public List<DepositExtendDto> GetDepositsByUserStatus(int user, int status);

        public List<DepositExtendDto> GetDepositsByAccountStatus(int account, int status);

        #endregion Methods

    }
}