using Eutech.SushisTech.BLL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eutech.SushisTech.Website.Controllers {

    public class BaseController : Controller {

        //on désactive le support async pour l'execute core
        protected override bool DisableAsyncSupport {
            get {
                return true;
            }
        }

        protected UserBO UserConnected { get; set; }

        protected override void ExecuteCore() {
            
            //si l'utilisateur est connecté, on le récupère depuis la session
            if(HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated) {
                
                if(!string.IsNullOrEmpty(HttpContext.User.Identity.Name)) {
                    
                    //si l'utilisateur n'est pas présent en session, on tente de l'insérer
                    if(Session["userConnected"] == null) {

                        long userId = 0;

                        if(long.TryParse(User.Identity.Name, out userId)) {

                            //insére le bo de l'utilisateur en session afin de le récupérer ailleurs
                            Session["userConnected"] = new UserBO(userId);
                        }
                    }

                    //on set la property de notre controlleur afin d'y avoir accès partout dans nos controleurs
                    UserConnected = (UserBO)Session["userConnected"];
                }
            }

            base.ExecuteCore();
        }
	}
}