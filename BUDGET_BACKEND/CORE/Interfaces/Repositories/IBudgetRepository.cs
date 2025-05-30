namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBudgetRepository
    {

        #region Métodos y Funciones

        public BudgetExtendDto? GetBudgetById(int idBudget);

        public BudgetExtendDto? GetBudgetByYearMonthUser(int year, int month, int idUser);

        public List<BudgetExtendDto> GetBudgetsByUser(int idUser);

        public List<BudgetExtendDto> GetBudgetsByStatus(int idStatus);

        public List<BudgetExtendDto> GetBudgetsByUserStatus(int idUser, int idStatus);

        #endregion 

    }
}