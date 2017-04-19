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
    public class TraderViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private DateTime _DateCreated = DateTime.Now;
        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                _DateCreated = value;
            }
        }

        [Required(ErrorMessage = "Please enter your company name.")]
        [MaxLength(255, ErrorMessage = "Name cannot be more than 255 character long")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Address.")]
        [MaxLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        [MaxLength(255)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [MaxLength(255)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 character long.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password does not match.")]
        [MaxLength(255)]
        public string ConfirmPassword { get; set; }

        private Boolean _IsActive = true;
        public Boolean IsActive
        {

            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
    }
}
