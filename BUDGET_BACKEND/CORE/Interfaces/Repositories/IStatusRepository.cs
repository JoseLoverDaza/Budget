namespace CORE.Interfaces.Repositories
{

    #region Using

    using Domain.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IStatusRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IStatusRepository
    {

        #region  Métodos y Funciones

        public StatusDto? GetStatusById(int id);
                
        public StatusDto? GetStatusByName(string name);

        public List<StatusDto> GetStatus(int status);

        #endregion

    }
}