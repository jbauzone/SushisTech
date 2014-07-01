using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Products {
    
    public class MenuProduct {

        public long Id { get; set; }

        public long? ParentProductId { get; set; }
        [ForeignKey("ParentProductId")]
        public Product ParentProduct { get; set; }

        public long? ChildProductId { get; set; }
        [ForeignKey("ChildProductId")]
        public Product ChildProduct { get; set; }
    }
}
