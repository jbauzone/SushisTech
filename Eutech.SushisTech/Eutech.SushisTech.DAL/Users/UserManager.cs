using Eutech.SushisTech.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Users {

    public class UserManager {

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
    }
}
