using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eutech.SushisTech.BLL.Securities;

namespace Eutech.SushisTech.Tests.Securities {

    [TestClass]
    public class SecurityTest {

        /// <summary>
        /// Vérifie la validité d'un hash
        /// </summary>
        [TestMethod]
        public void HashValidTest() {

            string data = "passwordpashashé";
            string expected = "5B41653D572AED6A63BE166359061B83CC06EC9E";

            Assert.AreEqual(expected, Encrypt.GetHash(data));
        }
    }
}
