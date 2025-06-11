namespace Domain.Dto.Common
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BaseDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BaseDto
    {

        #region Atributos y Propiedades

        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int ModificationUser { get; set; }
        public DateTime ModificationDate { get; set; } = DateTime.Now;

        #endregion

    }
}