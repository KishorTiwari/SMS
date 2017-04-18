using SMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.ViewModels
{
    public class StockViewModel: Vehicle
    {
        public int Id { get; set; }

        public int MyProperty { get; set; }
    }
}
