namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IStatusBudgetRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IStatusBudgetRepository
    {

        #region  Métodos y Funciones

        public StatusBudgetDto? GetStatusBudgetByIdStatusBudget(StatusBudgetDto statusBudget);

        public StatusBudgetDto? GetStatusBudgetByNameStatus(StatusBudgetDto statusBudget);

        public List<StatusBudgetDto> GetStatusBudget();

        #endregion

    }
}