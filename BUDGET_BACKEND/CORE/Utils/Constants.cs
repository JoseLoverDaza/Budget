namespace CORE.Utils
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Constants   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public static class Constants
    {

        #region Constantes

        public static class General
        {

            public const string APP_SETTIINGS_JSON_FILE_NAME = "appsettings.json";
            public const string CONNECTION_STRING_DATABASE_NAME = "DefaultConnection";
            public const string MESSAGE_GENERAL = "Ha ocurrido un error en la transacción. Consulte con el Administrador";
            public const string ALLOWED_HOST = "AllowedHosts";
            public const string SUCCESSUL = "Successful";
            public const string ERROR = "Error";
            public const string SUCCESSUL_SAVE = "Successful Save";
            public const string SUCCESSUL_EDIT = "Successful Edit";
            public const string SUCCESSUL_DELETE = "Successful Delete";
            public const string JSON_EMPTY = "{}";
        }

        public static class Status
        {
            public const string INACTIVO = "Inactivo";
            public const string ACTIVO = "Activo";
            public const string CANCELADO = "Cancelado";
        }

        public static class MethodHttp
        {
            public const string GET = "GET";
            public const string POST = "POST";
            public const string DELETE = "DELETE";            
            public const string TOKEN = "TOKEN";
            public const string VERIFY = "VERIFY";
        }

        public static class EntityAction
        {
            public const string CONSULT = "CONSULT";
            public const string SAVE = "SAVE";
            public const string UPDATE = "UPDATE";
            public const string DELETE = "DELETE";           
        }

        public static class UserBudget
        {
            public const string USERNAME_ADMIN = "Admin";            
        }

        #endregion

    }
}