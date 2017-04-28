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

        public DateTime DateEntered { get; set; }

        [Required]       
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int Kilometers { get; set; }
       
        [MaxLength(10)]
        public string Rego { get; set; }

        public float? CostPrice { get; set; }

        public float? SellingPrice { get; set; }

        public Boolean IsSold{ get; set; }

        public DateTime? DateSold { get; set; }
        
        public virtual Trader Trader { get; set; }
        public virtual ICollection<ExtraCost> ExtraCost { get; set; }
    }
}
