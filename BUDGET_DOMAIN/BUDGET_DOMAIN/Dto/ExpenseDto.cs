namespace Domain.Dto
{

    #region Librerias

    using Domain.Dto.Common;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ExpenseDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ExpenseDto : BaseDto
    {

        #region Atributos y Propiedades

        public int IdExpense { get; set; }
        public string NameExpense { get; set; } = null!;
        public string? DescriptionExpense { get; set; }

        public int IdTypeExpense { get; set; }

        public int IdStatusBudget { get; set; }        

        #endregion

    }
}