namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    
    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeExpenseService
    {

        #region Métodos y Funciones

        public TypeExpenseExtendDto? GetTypeExpenseById(int idTypeExpense);

        public TypeExpenseExtendDto? GetTypeExpenseByName(string name);

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(int idStatus);

        public TypeExpenseExtendDto SaveTypeExpense(TypeExpenseExtendDto typeExpense);

        public TypeExpenseExtendDto UpdateTypeExpense(TypeExpenseExtendDto typeExpense);

        public TypeExpenseExtendDto DeleteTypeExpense(TypeExpenseExtendDto typeExpense);

        #endregion

    }
}