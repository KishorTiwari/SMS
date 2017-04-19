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
        [MaxLength(20, ErrorMessage = "Phone number cannot be more than 20 charactor long")]
        [MinLength(8, ErrorMessage = "Phone number should  be at least charactor long")]
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
        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<ExtraCost> ExtraCost { get; set; }

    }
}
