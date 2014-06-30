using Eutech.SushisTech.BLL.Securities;
using Eutech.SushisTech.BLL.Users;
using Eutech.SushisTech.Models.Login;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace Eutech.SushisTech.Website.Controllers.Api {

    public class LoginController : BaseApiController {

        public string Post([FromBody] string data) {
            
            //TODO vérifier le nombre d'appels pour la session courante

            //model retourné par le service
            LoginResultViewModel model = new LoginResultViewModel { Result = false, Token = string.Empty };

            //déchiffre les données reçues
            string dataReceived = Encrypt.DecryptString(data);

            //on parse la chaine pour obtenir le json associé
            JObject obj = JObject.Parse(dataReceived);

            string email = string.Empty;
            string password = string.Empty;

            if(obj["Email"] != null && !string.IsNullOrEmpty(obj["Email"].ToString()))
                email = obj["Email"].ToString();

            if (obj["Password"] != null && !string.IsNullOrEmpty(obj["Password"].ToString()))
                password = obj["Password"].ToString();

            //on vérifie le couple
            long? userId = UserService.IsAuthenticationValid(email, password);

            //le couple est valide, on a le userId de l'utilisateur correspondant
            if(userId.HasValue) {

                UserBO user = new UserBO(userId.Value);

                //on récupère le token pour cet utilisateur
                model.Token = user.GetOrCreateToken();
                model.Result = true;
                
                //authentification de l'utilisateur
                FormsAuthentication.SetAuthCookie(userId.Value.ToString(), false);
            }

            return Encrypt.EncryptString(JsonConvert.SerializeObject(model));
        }
    }
}