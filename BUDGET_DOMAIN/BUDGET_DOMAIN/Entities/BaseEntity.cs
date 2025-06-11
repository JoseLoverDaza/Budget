namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BaseEntity   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public abstract class BaseEntity
    {

        public int CreatedUser { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUser { get; set; }

    }
}
