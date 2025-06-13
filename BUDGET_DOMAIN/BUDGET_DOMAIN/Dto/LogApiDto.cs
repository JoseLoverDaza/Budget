namespace Domain.Dto
{

    #region Librerias

    using Domain.Dto.Common;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: LogApiDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class LogApiDto : BaseDto
    {

        #region Atributos y Propiedades

        public int IdLogApi { get; set; }
        public string Entity { get; set; } = null!;
        public string EntityAction { get; set; } = null!;
        public string PreviousValues { get; set; } = null!;        
        public string NewValues { get; set; } = null!;
        public string FilterValues { get; set; } = null!;

        public int IdStatusBudget { get; set; }

        #endregion

    }
}