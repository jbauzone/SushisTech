using Eutech.SushisTech.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Users {

    public static class UserManager {

        /// <summary>
        /// Charge un utilisateur depuis le userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetUserById(long userId) {
            return ContextDAO.Context.Users.Find(userId);
        }

        /// <summary>
        /// Charge un utilisateur depuis l'email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static User GetUserByEmail(string email) {
            return ContextDAO.Context.Users.FirstOrDefault(u => u.Email == email);
        }
        
        /// <summary>
        /// Insère un token en base de données
        /// </summary>
        /// <param name="token">L'objet token à ajouter en base de données</param>
        /// <returns></returns>
        public static Token Insert(this Token token) {
            
            token = ContextDAO.Context.Tokens.Add(token);
            ContextDAO.Save();

            return token;
        }

        /// <summary>
        /// Récupère s'il existe le dernier token de l'utilisateur, null si inexistant
        /// </summary>
        /// <param name="userId">L'identifiant de l'utilisateur</param>
        /// <returns></returns>
        public static Token GetToken(long userId) {
            return ContextDAO.Context.Tokens.Where(t => t.UserId == userId).OrderByDescending(t => t.Date).FirstOrDefault();
        }
    }
}
