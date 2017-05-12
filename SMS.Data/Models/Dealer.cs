using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TraderId { get; set; }

        public virtual Trader Trader { get; set; }
    }
}
