namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetDetailExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetDetailExtendDto : BudgetDetailsDto
    {

        #region Atributos y Propiedades

        public short YearBudget { get; set; }
        public byte MonthBudget { get; set; }
        public string NameExpense { get; set; } = null!;
        public string? DescriptionExpense { get; set; }
        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}