using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class Trader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your company name.")]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Address.")]
        [Display(Name = "Address")]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter valid email address")]
        [Display(Name = "Email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [MaxLength(255)]
        public string CurrentPassword { get; set; }

        [MaxLength(255)]
        public string OldPassword { get; set; }

        [MaxLength(255)]
        public string TempPassword { get; set; }

        private Boolean _IsActive = true;
        public Boolean IsActive {

            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<ExtraCost> ExtraCost { get; set; }
       
    }
}
