namespace Domain.Dto
{

    #region Librerias

    using Domain.Dto.Common;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: DepositDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class DepositDto : BaseDto
    {

        #region Atributos y Propiedades

        public int IdDeposit { get; set; }
        public short YearDeposit { get; set; }
        public byte MonthDeposit { get; set; }
        public decimal Amount { get; set; }

        public int IdUserBudget { get; set; }
      
        public int IdAccount { get; set; }
        
        public int IdStatusBudget { get; set; }
       
        #endregion

    }
}