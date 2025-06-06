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

        public LogApiExtendDto? GetLogApiById(LogApiDto logApi);

        public List<LogApiExtendDto> GetlogApisByCreationDate(LogApiDto logApi);

        public List<LogApiExtendDto> GetlogApisByStatus(LogApiDto logApi);

        public List<LogApiExtendDto> GetlogApisByEntityCreationDate(LogApiDto logApi);

        public List<LogApiExtendDto> GetlogApisByCreationDateStatus(LogApiDto logApi);

        public List<LogApiExtendDto> GetlogApisByEntityCreationDateStatus(LogApiDto logApi);

        #endregion

    }
}