namespace Domain.Dto.Common
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: PaginationDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class ResponseDto
    {

        #region Attributes

        public bool Status { get; set; }

        public int Code { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }

        public PaginationDto? Pagination { get; set; }

        #endregion Attributes

        #region Constructor

        public ResponseDto() { }

        public ResponseDto(bool status, int code, string? message, object? data = null, PaginationDto? pagination = null)
        {
            Status = status;
            Code = code;
            Message = message;
            Data = data;
            Pagination = pagination;
        }

        #endregion Constructor

    }
}