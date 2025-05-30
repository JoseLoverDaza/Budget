namespace CORE.Interfaces.Repositories
{

    #region Using

    using CORE.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeExpenseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeExpenseRepository
    {

        #region Métodos y Funciones

        public TypeExpenseExtendDto? GetTypeExpenseById(int id);

        public TypeExpenseExtendDto? GetTypeExpenseByName(string name);

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(int status);

        #endregion Methods

    }
}