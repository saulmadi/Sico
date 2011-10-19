using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SiCo.sgla
{
    public static class Cripto
    {
        private static readonly TripleDESCryptoServiceProvider cr = new TripleDESCryptoServiceProvider();

        public static string Encriptar(string Texto)
        {
            byte[] TextoByte = Encoding.Unicode.GetBytes(Texto);


            var ms = new MemoryStream();

            var generadorLlave = new PasswordDeriveBytes(Keys.LLaveCryptografica, null);
            //cr.IV = Keys.VectorIncialiazacion;
            byte[] bytesLlaveSHA1 = generadorLlave.CryptDeriveKey("TripleDES", "SHA1", 192, Keys.VectorIncialiazacion);

            //cr.Key = bytesLlaveSHA1;
            //cr.Mode = CipherMode.ECB;
            //cr.Padding = PaddingMode.PKCS7;


            var encStream = new CryptoStream(ms, cr.CreateEncryptor(bytesLlaveSHA1, Keys.VectorIncialiazacion),
                                             CryptoStreamMode.Write);
            encStream.Write(TextoByte, 0, TextoByte.Length);
            encStream.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string DesEncriptar(string TextoEncriptado)
        {
            try
            {
                byte[] TextoByte = Convert.FromBase64String(TextoEncriptado);
                var ms = new MemoryStream();

                var generadorLlave = new PasswordDeriveBytes(Keys.LLaveCryptografica, null);

                //cr.IV = Keys.VectorIncialiazacion; 

                byte[] bytesLlaveSHA1 = generadorLlave.CryptDeriveKey("TripleDES", "SHA1", 192,
                                                                      Keys.VectorIncialiazacion);

                //cr.Key = bytesLlaveSHA1;
                //cr.Mode = CipherMode.ECB;
                //cr.Padding = PaddingMode.PKCS7;


                var encStream = new CryptoStream(ms, cr.CreateDecryptor(bytesLlaveSHA1, Keys.VectorIncialiazacion),
                                                 CryptoStreamMode.Write);
                encStream.Write(TextoByte, 0, TextoByte.Length);
                encStream.FlushFinalBlock();

                return Encoding.Unicode.GetString(ms.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }
    }

    internal static class Keys
    {
        public static byte[] LLaveCryptografica =
            Encoding.UTF8.GetBytes(new DateTime(2011, 08, 27).ToString("yyyy-MM-dd") + " " +
                                   new DateTime(2006, 08, 21).ToString("yyyy-MM-dd") + " " +
                                   new DateTime(1988, 07, 13).ToString("yyyy-MM-dd"));

        public static byte[] VectorIncialiazacion = Encoding.UTF7.GetBytes("luisandr");
        //Luis Andres Mayorquin Castro Irma Pamela Castro Saul Antonio Mayorquin Diaz");
    }
}