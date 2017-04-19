using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SMS.Data.Models;

namespace SMS.Data.Models
{
    public class Trader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private DateTime _DateCreated = DateTime.Now;
        public DateTime DateCreated{ get; set; }

        [Required]        
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string TempPassword { get; set; }

        public Boolean IsActive { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<ExtraCost> ExtraCost { get; set; }
       
    }
}
