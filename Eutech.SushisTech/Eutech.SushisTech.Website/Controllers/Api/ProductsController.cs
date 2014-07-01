using Eutech.SushisTech.BLL.Products;
using Eutech.SushisTech.BLL.Securities;
using Eutech.SushisTech.Models.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eutech.SushisTech.Website.Controllers.Api {

    public class ProductsController : BaseApiController {

        public string Get() {

            //on récupère l'ensemble des produits disponibles
            List<ProductItemViewModel> products = ProductService.GetProducts();

            //retourne les résultats chiffrés
            return Encrypt.EncryptString(JsonConvert.SerializeObject(products));
        }
    }
}
