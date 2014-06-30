using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Users {

    public class Token {

        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Value { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
