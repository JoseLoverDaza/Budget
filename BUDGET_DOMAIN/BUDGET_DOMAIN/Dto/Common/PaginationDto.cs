namespace Domain.Dto.Common
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: PaginationDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class PaginationDto
    {

        #region Atributos y Propiedades

        public int Page { get; set; }

        public int RecordPage { get; set; }

        public int TotalRecords { get; set; }

        #endregion

    }
}