﻿using Eutech.SushisTech.DAL.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Orders {

    public class Order {

        public long Id { get; set; }

        public long? MenuId { get; set; }
        public Menu Menu { get; set; }

        public long? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
