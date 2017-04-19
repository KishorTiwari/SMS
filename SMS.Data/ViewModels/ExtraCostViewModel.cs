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
    public class ExtraCostViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        [ForeignKey("Trader")]
        public int TraderId { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public float Cost { get; set; }

    }
}
