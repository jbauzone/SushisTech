using Eutech.SushisTech.BLL.Products;
using Eutech.SushisTech.Models.Home;
using Eutech.SushisTech.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eutech.SushisTech.Website.Controllers {

    public class HomeController : BaseController {

        public ActionResult Index() {

            //on récupère l'ensemble des produits disponibles
            List<ProductItemViewModel> products = ProductService.GetProducts();

            HomeViewModel model = new HomeViewModel();
            model.Products = products;

            return View(model);
        }
	}
}