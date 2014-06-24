using Eutech.SushisTech.DAL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Orders {

    public class OrderHistory {
        
        public long Id { get; set; }
        public DateTime ActionDate { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
