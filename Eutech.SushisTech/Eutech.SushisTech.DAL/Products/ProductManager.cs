using Eutech.SushisTech.DAL.Context;
using Eutech.SushisTech.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Products {
    
    public class ProductManager {

        /// <summary>
        /// Retourne la requête de récupération des produits disponibles
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProductItemViewModel> GetProducts() {

            var query = (from p in ContextDAO.Context.Products
                         select new ProductItemViewModel {
                            Name = p.Name
                         });

            return query;
        }
    }
}
