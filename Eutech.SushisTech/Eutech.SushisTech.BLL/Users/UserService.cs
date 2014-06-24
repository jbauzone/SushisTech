using Eutech.SushisTech.BLL.Securities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.BLL.Users {

    public class UserService {

        /// <summary>
        /// Vérifie si le couple email/mot de passe correspond à un utilisateur valide
        /// </summary>
        /// <param name="email">Email de l'utilisateur</param>
        /// <param name="password">Mot de passe en clair de l'utilisateur</param>
        /// <returns>Le userId si valide, null sinon</returns>
        public static long? IsAuthenticationValid(string email, string password) {
    
            //charge l'utilisateur depuis son email afin de récupérer son id
            UserBO user = new UserBO(email);

            //aucun utilisateur n'existe avec cet email
            if(user.Id == 0)
                return null;

            //vérification du mot de passe sur l'utilisateur
            //on formatte le mot de passe userId!password et on récupère le hash
            string passwordHash = Encrypt.GetHash(string.Format("{0}!{1}", user.Id, password));

            //si le pass match, on retourne l'id de l'utilisateur
            if (user.Password == passwordHash)
                return user.Id;

            return null;
        }
    }
}
