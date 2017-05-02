using SMS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Data.Validations;

namespace SMS.Data.ViewModels
{
    public class VehicleViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TraderId { get; set; }

        private DateTime _DateEntered = DateTime.UtcNow;
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
        [DisplayFormat(DataFormatString = "{0:0,#}")]
        [Display(Name = "Kilometers")]
        public int Kilometers { get; set; }

        [Required(ErrorMessage = "Please enter Registration Number")]
        [MaxLength(10)]
        [Display(Name = "Rego")]
        [RegularExpression(@"\w+", ErrorMessage = "Please enter valid registration number.")]
        public string Rego { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Cost Price")]
        public decimal? CostPrice { get; set; }

        [Display(Name = "Selling Price")]
        public decimal? SellingPrice { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateNow]
        [StatusSold]
        public DateTime? DateSold { get; set; }

    }
}
