namespace CORE.Dto
{

    #region Using

    using Domain.Dto;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ExpenseExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ExpenseExtendDto : ExpenseDto
    {

        #region Atributos y Propiedades

        public string NameTypeExpense { get; set; } = null!;
        public string? DescriptionTypeExpense { get; set; }
        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}