using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Utilisateurs {

    public class Utilisateur {

        public long Id { get; set; }
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string MotDePasse { get; set; }
    }
}
