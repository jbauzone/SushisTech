using System;
using System.Collections.Generic;
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
    }
}
