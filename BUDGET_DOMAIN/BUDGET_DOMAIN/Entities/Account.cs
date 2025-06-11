namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Account   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class Account : BaseEntity
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