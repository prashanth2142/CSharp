namespace CoreAPI.Services
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    public class CryptoService
    {
        private static readonly string NeaKey = "gV3X6c07KZRt620cdT2c0oA1";
        public static string DESEncrypt(string stringToEncrypt)
        {
            if (string.IsNullOrEmpty(stringToEncrypt))
                return string.Empty;

            using var md5Provider = MD5.Create();
            using var tripleDES = new TripleDESCryptoServiceProvider
            {
                Key = md5Provider.ComputeHash(Encoding.UTF8.GetBytes(NeaKey)),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var bytesToEncrypt = Encoding.UTF8.GetBytes(stringToEncrypt);
            using var encryptor = tripleDES.CreateEncryptor();

            var encryptedBytes = encryptor.TransformFinalBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DESDecrypt(string stringToDecrypt)
        {
            if (string.IsNullOrEmpty(stringToDecrypt))
                return string.Empty;

            using var md5Provider = MD5.Create();
            using var tripleDES = new TripleDESCryptoServiceProvider
            {
                Key = md5Provider.ComputeHash(Encoding.UTF8.GetBytes(NeaKey)),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var bytesToDecrypt = Convert.FromBase64String(stringToDecrypt);
            using var decryptor = tripleDES.CreateDecryptor();

            var decryptedBytes = decryptor.TransformFinalBlock(bytesToDecrypt, 0, bytesToDecrypt.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
