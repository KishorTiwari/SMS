using SMS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.ViewModels
{
    public class VehicleViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TraderId { get; set; }

        private DateTime _DateEntered = DateTime.Now;
        public DateTime DateEntered
        {
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
        [MaxLength(50, ErrorMessage = "Sorry. Maximum 50 Characters are allowed. ")]
        [Display(Name = "Make")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please enter vehicle model")]
        [MaxLength(50, ErrorMessage = "Sorry. Maximum 50 Characters are allowed. ")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter Kilometers")]
        [Display(Name = "Kilometers")]
        public int Kilometers { get; set; }

        [Required(ErrorMessage = "Please enter Registration Number")]
        [MaxLength(10)]
        [Display(Name = "Rego")]
        public string Rego { get; set; }

        [Display(Name = "Cost Price")]
        public float? CostPrice { get; set; }

        [Display(Name = "Selling Price")]
        public float? SellingPrice { get; set; }

        [Required]
        [Display(Name = "Status")]
        [MaxLength(1)]
        public int Status { get; set; }
        public DateTime? DateSold { get; set; }
    }
}
