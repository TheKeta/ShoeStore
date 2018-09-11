using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.ViewModel
{
    public class UserVM
    {
        
        public Guid Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        [MaxLength(150, ErrorMessage = "Enter valid first name.")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MaxLength(150, ErrorMessage = "Enter valid last name.")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Delivert Address")]
        [MaxLength(150, ErrorMessage = "Enter valid address.")]
        public string Address { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Enter valid email.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirmation { get; set; }
    }
}