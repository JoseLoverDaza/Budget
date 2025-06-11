namespace Domain.Dto
{

    #region Librerias

    using Domain.Dto.Common;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeExpenseDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class TypeExpenseDto : BaseDto
    {

        #region Atributos y Propiedades

        public int IdTypeExpense { get; set; }
        public string NameTypeExpense { get; set; } = null!;
        public string? DescriptionTypeExpense { get; set; }

        public int IdStatusBudget { get; set; }

        #endregion

    }
}