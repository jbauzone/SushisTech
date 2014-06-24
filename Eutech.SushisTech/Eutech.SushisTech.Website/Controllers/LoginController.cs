using Eutech.SushisTech.BLL.Users;
using Eutech.SushisTech.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Eutech.SushisTech.Website.Controllers {

    public class LoginController : BaseController {
        
        public ActionResult Index() {
            return View(new LoginViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(LoginViewModel model) {

            if (ModelState.IsValid) {

                //on vérifie le couple
                long? userId = UserService.IsAuthenticationValid(model.Email, model.Password);

                //le couple est valide, on a le userId de l'utilisateur correspondant
                if(userId.HasValue) {

                    //authentification de l'utilisateur
                    FormsAuthentication.SetAuthCookie(userId.Value.ToString(), model.RememberMe);
                    return RedirectToAction("index", "home");
                }
            }

            return View(model);
        }
	}
}