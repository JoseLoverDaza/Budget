namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AccountDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AccountDto
    {

        #region Atributos y Propiedades

        public int IdAccount { get; set; }
        public string NameAccount { get; set; } = null!;
        public string? DescriptionAccount { get; set; }

        public int IdFinancialInstitution { get; set; }
        
        public int IdTypeAccount { get; set; }
      
        public int IdUserBudget { get; set; }
      
        public int IdStatusBudget { get; set; }
      
        #endregion

    }
}