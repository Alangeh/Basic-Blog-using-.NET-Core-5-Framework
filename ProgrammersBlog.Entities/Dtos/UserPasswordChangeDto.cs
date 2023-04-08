using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionsTimes.Entities.Dtos
{
   public class UserPasswordChangeDto
    {
        [DisplayName("Current Password")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(30, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(30, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field cannot be less than {1} characters")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Repeat New Password")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(30, ErrorMessage = "{0} field cannot be more than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field cannot be less than {1} characters.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage = "Your new password and repeated new passwords must match.")]
        public string RepeatPassword { get; set; }
    }
}
