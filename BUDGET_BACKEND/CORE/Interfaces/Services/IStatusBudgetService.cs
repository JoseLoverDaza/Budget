namespace CORE.Interfaces.Services
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IStatusBudgetService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IStatusBudgetService
    {

        #region  Métodos y Funciones

        public StatusBudgetDto? GetStatusBudgetByIdStatusBudget(StatusBudgetDto statusBudget);

        public StatusBudgetDto? GetStatusBudgetByNameStatus(StatusBudgetDto statusBudget);

        public List<StatusBudgetDto> GetStatusBudget();

        public StatusBudgetDto SaveStatusBudget(StatusBudgetDto statusBudget);

        public StatusBudgetDto UpdateStatusBudget(StatusBudgetDto statusBudget);

        #endregion

    }
}