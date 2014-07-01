using Eutech.SushisTech.DAL.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Orders {

    public class OrderItem {

        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal VAT { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
