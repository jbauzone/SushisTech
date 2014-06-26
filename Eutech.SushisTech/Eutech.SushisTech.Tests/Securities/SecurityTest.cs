using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eutech.SushisTech.BLL.Securities;

namespace Eutech.SushisTech.Tests.Securities {

    [TestClass]
    public class SecurityTest {

        //clé de test utilisée pour les tests de chiffrement
        private const string _keyValue = "19iz12da";
        private const string _ivValue = "zh9ka769";

        /// <summary>
        /// Vérifie la validité d'un hash
        /// </summary>
        [TestMethod]
        public void HashValidTest() {

            string data = "passwordpashashé";
            string expected = "5B41653D572AED6A63BE166359061B83CC06EC9E";

            Assert.AreEqual(expected, Encrypt.GetHash(data));
        }
        
        /// <summary>
        /// Vérifie le chiffrement
        /// </summary>
        [TestMethod]
        public void EncryptionValidTest() {

            string data = "chaîneenclair";
            string expected = "wApZF8oEcEZdlmxI4MVBDQ==";

            Assert.AreEqual(expected, Encrypt.EncryptString(data, _keyValue, _ivValue));
        }
        
        /// <summary>
        /// Vérifie le déchiffrement
        /// </summary>
        [TestMethod]
        public void DecryptionValidTest() {

            string data = "wApZF8oEcEZdlmxI4MVBDQ==";
            string expected = "chaîneenclair";

            Assert.AreEqual(expected, Encrypt.DecryptString(data, _keyValue, _ivValue));
        }
    }
}
