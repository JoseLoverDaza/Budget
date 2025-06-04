namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ILogRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ILogRepository
    {

        #region Métodos y Funciones

        public LogExtendDto? GetLogById(LogDto log);

        public List<LogExtendDto> GetLogsByCreationDate(LogDto log);

        public List<LogExtendDto> GetLogsByStatus(LogDto log);

        public List<LogExtendDto> GetLogsByEntityCreationDate(LogDto log);

        public List<LogExtendDto> GetLogsByCreationDateStatus(LogDto log);

        public List<LogExtendDto> GetLogsByEntityCreationDateStatus(LogDto log);

        #endregion

    }
}