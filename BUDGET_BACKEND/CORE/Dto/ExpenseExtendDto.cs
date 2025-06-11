namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

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

        public string NameStatusBudget { get; set; } = null!;
        public string? DescriptionStatusBudget { get; set; }

        #endregion

    }
}