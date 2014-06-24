using Eutech.SushisTech.DAL.Commandes;
using Eutech.SushisTech.DAL.Produits;
using Eutech.SushisTech.DAL.Utilisateurs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Context {

    public class SushisContext : DbContext {

        public DbSet<Commande> Commandes { get; set; }
        public DbSet<CommandeHistory> CommandesHistories { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}
