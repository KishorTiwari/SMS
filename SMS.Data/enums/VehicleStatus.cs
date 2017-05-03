using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.enums
{
    public enum Status
    {
        [Display(Name = "Available")]
        Available = 1,

        [Display(Name = "Sold")]
        Sold = 2,

        [Display(Name = "Sale Pending")]
        SalePending = 3
    }
}
