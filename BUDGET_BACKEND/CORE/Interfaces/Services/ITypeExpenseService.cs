namespace CORE.Interfaces.Services
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeExpenseService   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeExpenseService
    {

        #region Métodos y Funciones

        public TypeExpenseExtendDto? GetTypeExpenseById(TypeExpenseDto typeExpense);

        public TypeExpenseExtendDto? GetTypeExpenseByName(TypeExpenseDto typeExpense);

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(TypeExpenseDto typeExpense);

        public TypeExpenseDto SaveTypeExpense(TypeExpenseDto typeExpense);

        public TypeExpenseDto UpdateTypeExpense(TypeExpenseDto typeExpense);

        public TypeExpenseDto DeleteTypeExpense(TypeExpenseDto typeExpense);

        #endregion

    }
}