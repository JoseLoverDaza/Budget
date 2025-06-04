namespace CORE.Interfaces.Repositories
{

    #region Librerias

    using CORE.Dto;
    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ITypeExpenseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface ITypeExpenseRepository
    {

        #region Métodos y Funciones

        public TypeExpenseExtendDto? GetTypeExpenseById(TypeExpenseDto typeExpense);

        public TypeExpenseExtendDto? GetTypeExpenseByName(TypeExpenseDto typeExpense);

        public List<TypeExpenseExtendDto> GetTypeExpensesByStatus(TypeExpenseDto typeExpense);

        #endregion

    }
}