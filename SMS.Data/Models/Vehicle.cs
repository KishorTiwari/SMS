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

        private DateTime _DateEntered = DateTime.Now;
        public DateTime DateEntered {
            get
            {
                return _DateEntered;
            }
            set
            {
                _DateEntered = value;
            }
        }

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
       
        [MaxLength(10)]
        [Display(Name = "Rego")]
        public string Rego { get; set; }

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
        public DateTime DateSold { get; set; }

        public virtual Trader Trader { get; set; }
        public virtual ICollection<ExtraCost> ExtraCost { get; set; }
    }
}
