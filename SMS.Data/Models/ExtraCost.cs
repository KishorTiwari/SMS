﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class ExtraCost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateEntered { get; set; }
     
        public int TraderId { get; set; }

        public int VehicleId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        public virtual Trader Trader { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
