using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.AccessControl;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.IO;

namespace SiCo.sgla
{
    public static  class Cripto
    {
        static  TripleDESCryptoServiceProvider cr = new TripleDESCryptoServiceProvider();
        
        public static string Encriptar(string Texto)
        {
            byte[] TextoByte = System.Text.Encoding.Unicode.GetBytes(Texto);
            
            
            MemoryStream ms = new MemoryStream(); 
            
            PasswordDeriveBytes generadorLlave = new PasswordDeriveBytes(Keys.LLaveCryptografica, null);
            //cr.IV = Keys.VectorIncialiazacion;
            byte[] bytesLlaveSHA1 = generadorLlave.CryptDeriveKey("TripleDES", "SHA1", 192, Keys.VectorIncialiazacion);

            //cr.Key = bytesLlaveSHA1;
            //cr.Mode = CipherMode.ECB;
            //cr.Padding = PaddingMode.PKCS7;


            CryptoStream encStream = new CryptoStream(ms,cr.CreateEncryptor(bytesLlaveSHA1,Keys.VectorIncialiazacion)   , CryptoStreamMode.Write);
            encStream.Write(TextoByte,0,TextoByte.Length);  
            encStream.FlushFinalBlock() ;

            return Convert.ToBase64String (ms.ToArray());

        }

        public static string DesEncriptar(string TextoEncriptado)
        {
            byte[] TextoByte = Convert.FromBase64String  (TextoEncriptado)
;
            MemoryStream ms = new MemoryStream();
            
            PasswordDeriveBytes generadorLlave = new PasswordDeriveBytes(Keys.LLaveCryptografica, null);

            //cr.IV = Keys.VectorIncialiazacion; 

            byte[] bytesLlaveSHA1 = generadorLlave.CryptDeriveKey("TripleDES", "SHA1", 192, Keys.VectorIncialiazacion );
             
            //cr.Key = bytesLlaveSHA1;
            //cr.Mode = CipherMode.ECB;
            //cr.Padding = PaddingMode.PKCS7;

            
            CryptoStream encStream = new CryptoStream(ms, cr.CreateDecryptor(bytesLlaveSHA1,Keys.VectorIncialiazacion) , CryptoStreamMode.Write );
            encStream.Write(TextoByte, 0, TextoByte.Length);
            encStream.FlushFinalBlock();

            return System.Text.Encoding.Unicode.GetString(ms.ToArray());

        }        
    }

    internal  static class Keys
    {
        public static byte[] LLaveCryptografica = Encoding.UTF8.GetBytes(new DateTime(2011, 08, 27).ToString("yyyy-MM-dd") + " " +
                                                                                       new DateTime(2006, 08, 21).ToString("yyyy-MM-dd") +" "+
                                                                                       new DateTime(1988, 07, 13).ToString("yyyy-MM-dd") );

        public static byte[] VectorIncialiazacion = System.Text.Encoding.UTF7.GetBytes("luisandr");
            //Luis Andres Mayorquin Castro Irma Pamela Castro Saul Antonio Mayorquin Diaz");
    }
}
