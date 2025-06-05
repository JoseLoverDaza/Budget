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

        public LogExtendDto? GetLogById(LogDto log);

        public List<LogExtendDto> GetLogsByCreationDate(LogDto log);

        public List<LogExtendDto> GetLogsByStatus(LogDto log);

        public List<LogExtendDto> GetLogsByEntityCreationDate(LogDto log);

        public List<LogExtendDto> GetLogsByCreationDateStatus(LogDto log);

        public List<LogExtendDto> GetLogsByEntityCreationDateStatus(LogDto log);

        public LogDto SaveLog(LogDto log);

        public LogDto UpdateLog(LogDto log);

        public LogDto DeleteLog(LogDto log);

        #endregion

    }
}