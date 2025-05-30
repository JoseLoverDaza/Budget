namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeExpenseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeExpenseRepository
    {

        #region Métodos y Funciones

        public TypeExpenseExtendDto? GetTypeExpenseById(int idTypeExpense);

        public TypeExpenseExtendDto? GetTypeExpenseByName(string name);

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(int idStatus);

        #endregion

    }
}