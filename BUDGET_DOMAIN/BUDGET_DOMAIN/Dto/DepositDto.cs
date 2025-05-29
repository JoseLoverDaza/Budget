namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AccountDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class DepositDto
    {

        #region Atributos y Propiedades

        public int IdDeposit { get; set; }
        public short Year { get; set; }
        public byte Month { get; set; }
        public decimal Amount { get; set; }

        public int IdUser { get; set; }
      
        public int IdAccount { get; set; }
        
        public int IdStatus { get; set; }
       
        #endregion

    }
}