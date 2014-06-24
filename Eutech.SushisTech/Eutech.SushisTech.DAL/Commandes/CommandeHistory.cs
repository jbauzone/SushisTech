using Eutech.SushisTech.DAL.Utilisateurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Commandes {

    public class CommandeHistory {
        
        public long Id { get; set; }
        public DateTime DateAction { get; set; }

        public long CommandeId { get; set; }
        public Commande Commande { get; set; }

        public long UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
