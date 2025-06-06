namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ILogService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ILogService
    {

        #region Métodos y Funciones

        public LogApiExtendDto? GetLogById(LogDto log);

        public List<LogApiExtendDto> GetLogsByCreationDate(LogDto log);

        public List<LogApiExtendDto> GetLogsByStatus(LogDto log);

        public List<LogApiExtendDto> GetLogsByEntityCreationDate(LogDto log);

        public List<LogApiExtendDto> GetLogsByCreationDateStatus(LogDto log);

        public List<LogApiExtendDto> GetLogsByEntityCreationDateStatus(LogDto log);

        public LogDto SaveLog(LogDto log);

        public LogDto UpdateLog(LogDto log);

        public LogDto DeleteLog(LogDto log);

        #endregion

    }
}