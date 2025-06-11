namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ILogApiRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ILogApiRepository
    {

        #region Métodos y Funciones

        public LogApiExtendDto? GetLogApiByIdLogApi(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByCreationDate(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByStatusBudget(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByEntityCreationDate(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByCreationDateStatusBudget(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByEntityCreationDateStatusBudget(LogApiDto logApi);

        #endregion

    }
}