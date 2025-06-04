namespace API.Helper
{

    #region Librerias

    using System.Security.Cryptography;
    using System.Text;
    using Microsoft.Extensions.Configuration;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: EncryptionHelper   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public static class EncryptionHelper
    {

        #region Atributos y Propiedades

        private static IConfiguration? _configuration;
        
        #endregion

        #region Métodos y Funciones

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static byte[] GetKey()
        {
            string projectName = _configuration?["Encryption:ProjectName"]
                ?? throw new InvalidOperationException("ProjectName no configurado.");
            return SHA256.HashData(Encoding.UTF8.GetBytes(projectName)).Take(32).ToArray();
        }

        public static string Encrypt(string plainText)
        {
            byte[] key = GetKey();
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.GenerateIV();

            using MemoryStream ms = new();            
            ms.Write(aes.IV, 0, aes.IV.Length);

            using (CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (StreamWriter sw = new(cs))
            {
                sw.Write(plainText);
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] fullCipher = Convert.FromBase64String(encryptedText);
            byte[] key = GetKey();

            byte[] iv = fullCipher.Take(16).ToArray();
            byte[] cipher = fullCipher.Skip(16).ToArray();

            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using MemoryStream ms = new(cipher);
            using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader sr = new(cs);

            return sr.ReadToEnd();
        }

        #endregion

    }
}