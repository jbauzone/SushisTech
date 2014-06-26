using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.BLL.Securities {

    public class Encrypt {

        /// <summary>
        /// Génère le hash SHA1 de la chaine passée
        /// </summary>
        /// <param name="data">La chaine en clair dont il faut créer le hash</param>
        /// <returns></returns>
        public static string GetHash(string data) {

            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException("data");

            string hashData = BitConverter.ToString(SHA1.Create()
                                .ComputeHash(Encoding.Default.GetBytes(data)))
                                .Replace("-", "");

            return hashData;
        }

        /// <summary>
        /// Permet de convertir une chaine dans un tableau de byte
        /// </summary>
        /// <param name="strInput">La chaine</param>
        /// <returns></returns>
        private static byte[] ConvertToByteArray(string strInput) {

            int intCounter; 
            char[] arrChar = strInput.ToCharArray();

            byte[] arrByte = new byte[arrChar.Length];

            for (intCounter = 0; intCounter < arrByte.Length; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }

        /// <summary>
        /// Chiffre une chaine selon la clé fournie
        /// </summary>
        /// <param name="value">La chaine à chiffrer</param>
        /// <param name="keyValue">La clé à utiliser pour chiffrer</param>
        /// <param name="keyIV">Vecteur d'initialisation</param>
        /// <returns></returns>
        public static string EncryptString(string value, string keyValue, string keyIV) {
            
            byte[] key = ConvertToByteArray(keyValue);
            byte[] IV = ConvertToByteArray(keyIV);

            byte[] inputByteArray = Encoding.UTF8.GetBytes(value);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream(); 
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
		}

        /// <summary>
        /// Déchiffre une chaine selon la clé fournie
        /// </summary>
        /// <param name="value">La chaine à déchiffrer</param>
        /// <param name="keyValue">La clé à utiliser pour déchiffrer</param>
        /// <param name="keyIV">Vecteur d'initialisation</param>
        /// <returns></returns>
		public static string DecryptString(string value, string keyValue, string keyIV) {
            
            byte[] key = ConvertToByteArray(keyValue);
            byte[] IV = ConvertToByteArray(keyIV);

            int len = value.Length;
            byte[] inputByteArray = Convert.FromBase64String(value);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();

            Encoding encoding = Encoding.UTF8; 
            return encoding.GetString(ms.ToArray());
		}

        /// <summary>
        /// Chiffre une chaine avec la clé par défaut du fichier de configuration
        /// </summary>
        /// <param name="value">La chaine à chiffrer</param>
        /// <returns></returns>
		public static string EncryptString(string value) {
            return EncryptString(value, ConfigurationManager.AppSettings["keyValue"], ConfigurationManager.AppSettings["keyIV"]);
		}

        /// <summary>
        /// Déchiffre une chaine chiffrée avec la clé par défaut du fichier de configuration
        /// </summary>
        /// <param name="value">La chaine à déchiffrer</param>
        /// <returns></returns>
		public static string DecryptString(string value) {
            return DecryptString(value, ConfigurationManager.AppSettings["keyValue"], ConfigurationManager.AppSettings["keyIV"]);
		}
    }
}
