namespace CORE.Interfaces.Repositories
{

    #region Using

    using CORE.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBudgetRepository
    {

        #region Métodos y Funciones

        public DepositExtendDto? GetDepositById(int id);

        public DepositExtendDto? GetDepositByName(string name);

        #endregion Using

    }
}