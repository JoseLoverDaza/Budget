namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;
    
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ILogApiService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ILogApiService
    {

        #region Métodos y Funciones

        public LogApiExtendDto? GetLogApiByIdLogApi(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByCreationDate(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByStatusBudget(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByEntityCreationDate(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByCreationDateStatusBudget(LogApiDto logApi);

        public List<LogApiExtendDto> GetLogApisByEntityCreationDateStatusBudget(LogApiDto logApi);

        public LogApiDto SaveLogApi(LogApiDto logApi);

        public LogApiDto UpdateLogApi(LogApiDto logApi);

        public LogApiDto DeleteLogApi(LogApiDto logApi);

        public void TraceLog(string entity, string entityAction, string previousValues, string newValues, string filterValues, DateTime creationDate, int? idStatus);

        #endregion

    }
}