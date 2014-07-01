using Eutech.SushisTech.DAL.Products;
using Eutech.SushisTech.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.BLL.Products {

    public class ProductService {

        /// <summary>
        /// Récupère l'ensemble des produits disponibles
        /// </summary>
        /// <returns></returns>
        public static List<ProductItemViewModel> GetProducts() {
            return ProductManager.GetProducts().ToList();
        }
    }
}
