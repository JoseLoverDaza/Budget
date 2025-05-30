namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IStatusRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IStatusRepository
    {

        #region  Métodos y Funciones

        public StatusDto? GetStatusById(int idStatus);
                
        public StatusDto? GetStatusByName(string name);

        public List<StatusDto> GetStatus();

        #endregion

    }
}