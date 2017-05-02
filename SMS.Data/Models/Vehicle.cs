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

        public int TraderId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateEntered { get; set; }

        [Required]       
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:0,#}")]
        public int Kilometers { get; set; }
       
        [MaxLength(10)]
        public string Rego { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal? CostPrice { get; set; }

        public decimal? SellingPrice { get; set; }

        public int Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateSold { get; set; }
        
        public virtual Trader Trader { get; set; }
        public virtual ICollection<ExtraCost> ExtraCost { get; set; }
    }
}
