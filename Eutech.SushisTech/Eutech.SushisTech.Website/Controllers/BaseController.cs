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
	}
}