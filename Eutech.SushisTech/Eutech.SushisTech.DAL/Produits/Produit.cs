using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Produits {

    public class Produit {
        
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Prix { get; set; }
        public decimal TauxTva { get; set; }
    }
}
