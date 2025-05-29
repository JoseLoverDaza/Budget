namespace Domain.Exceptions
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BusinessException   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BusinessException : Exception
    {

        #region Constructor
               
        public BusinessException(string message) : base(message)
        {
        }
               
        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion

    }
}