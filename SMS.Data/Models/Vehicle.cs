using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter vehicle make")]
        [Display(Name = "Make")]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please enter vehicle model")]
        [Display(Name = "Model")]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter Kilometers")]
        [Display(Name = "Kilometers")]
        public int? Kilometers { get; set; }

        [Required(ErrorMessage = "Please enter cost price")]
        [Display(Name = "Cost Price")]
        public float? CostPrice { get; set; }

        [Display(Name = "Selling Price")]
        public float? SellingPrice { get; set; }

        private Boolean _IsSold = false;
        public Boolean IsSold
        {
            get
            {
                return _IsSold;
            }
            set
            {
                _IsSold = value;
            }
        }

        public virtual Trader Trader { get; set; }
        public virtual ICollection<ExtraCost> ExtraCost { get; set; }
    }
}
