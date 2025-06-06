namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: LogApiDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class LogApiDto
    {

        #region Atributos y Propiedades

        public int IdLogApi { get; set; }
        public string Entity { get; set; } = null!;
        public string PreviousValues { get; set; } = null!;
        public string NewValues { get; set; } = null!;
        public string EntityAction { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int IdStatus { get; set; }

        #endregion

    }
}