namespace CORE.Utils
{

    #region Librerias

    using System.Reflection;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: Json   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public static class Json
    {

        #region Atributos

        private static readonly JsonSerializerOptions _cachedOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };

        #endregion

        #region Métodos y Funciones

        /// <summary>
        /// Reemplaza las propiedades string vacías o en blanco por null.
        /// </summary>
        public static T CleanEmptyStrings<T>(T obj) where T : class
        {
            if (obj == null)
            {
                return obj!;
            }

            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string) && p.CanRead && p.CanWrite);

            foreach (var prop in props)
            {
                var value = prop.GetValue(obj) as string;
                if (string.IsNullOrWhiteSpace(value))
                {
                    prop.SetValue(obj, null);
                }
            }
            return obj;
        }

        /// <summary>
        /// Serializa un objeto ignorando valores nulos y limpiando strings vacíos.
        /// Usa configuración cacheada para optimizar el rendimiento.
        /// </summary>
        public static string SerializeWithoutNulls<T>(T obj) where T : class
        {
            var cleaned = CleanEmptyStrings(obj);
            return JsonSerializer.Serialize(cleaned, _cachedOptions);
        }

        #endregion

    }
}