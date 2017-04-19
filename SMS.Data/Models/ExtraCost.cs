﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SMS.Data.Model;

namespace SMS.Data.Models
{
    public class ExtraCost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateEntered { get; set; }
     
        public int TraderId { get; set; }

        public int VehicleId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public float Cost { get; set; }

        public virtual Trader Trader { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
