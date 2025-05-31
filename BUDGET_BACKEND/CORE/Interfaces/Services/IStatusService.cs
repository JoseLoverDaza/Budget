namespace CORE.Interfaces.Services
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IStatusService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IStatusService
    {

        #region  Métodos y Funciones

        public StatusDto? GetStatusById(int idStatus);

        public StatusDto? GetStatusByName(string name);

        public List<StatusDto> GetStatus();

        public StatusDto SaveStatus(StatusDto status);

        public StatusDto UpdateStatus(StatusDto status);

        public StatusDto DeleteStatus(StatusDto status);

        #endregion

    }
}