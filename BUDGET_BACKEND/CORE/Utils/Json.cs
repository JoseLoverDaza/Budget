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

        #region Métodos y Funciones

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

        public static string SerializeWithoutNulls<T>(T obj) where T : class
        {
            var cleaned = CleanEmptyStrings(obj);

            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(cleaned, options);
        }

        #endregion

    }
}