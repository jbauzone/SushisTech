using Eutech.SushisTech.DAL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.BLL.Users {

    public class UserBO {

        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Construis un utilisateur depuis le userId fourni
        /// </summary>
        /// <param name="userId"></param>
        public UserBO(long userId) {

            User user = UserManager.GetUserById(userId);
            LoadInternal(user);
        }

        /// <summary>
        /// Construis un utilisateur depuis l'email fourni
        /// </summary>
        /// <param name="email"></param>
        public UserBO(string email) {

            User user = UserManager.GetUserByEmail(email);
            LoadInternal(user);
        }

        /// <summary>
        /// Mappe les données de l'utilisateur vers les propriétés
        /// </summary>
        /// <param name="user"></param>
        private void LoadInternal(User user) {

            if (user != null) {

                Id = user.Id;
                Email = user.Email;
                Password = user.Password;
            }
        }
    }
}
